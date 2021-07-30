﻿using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    class GraphManagment
    {
        class GraphManagement 
        {
            private IDb _db;
            
            public GraphManagement()
            {
                _db = new DalFactory().GetDb();
               
            }
            public void AddGraph(CategoryGraph categoryGraph)
            {
                if (categoryGraph.Categories == null || categoryGraph.Categories.Count < 0)
                    throw (new ArgumentException());
                _db.CategoryGraphs.Add(categoryGraph);
                _db.SaveChanges();
            }

            public void AddGraph(ProductGraph productGraph)
            {
                if (productGraph.Products == null || productGraph.Products.Count < 0)
                    throw (new ArgumentException());
                _db.ProductGraphs.Add(productGraph);
                _db.SaveChanges();
            }

            public void AddGraph(StoreGraph storeGraph)
            {
                if (storeGraph.Stores == null || storeGraph.Stores.Count < 0)
                    throw (new ArgumentException());
                _db.StoreGraphs.Add(storeGraph);
                _db.SaveChanges();
            }

            public void AddGraph(ShoppingCartGraph shoppingCartGraph)
            {
                if (shoppingCartGraph.ShoppingCarts == null || shoppingCartGraph.ShoppingCarts.Count < 0)
                    throw (new ArgumentException());
                _db.TransactionsGraphs.Add(shoppingCartGraph);
                _db.SaveChanges();
            }

            public IEnumerable<BasicGraph> GetCategoryGraphs()
            {
                return _db.CategoryGraphs;
            }

            public IEnumerable<BasicGraph> GetProductGraphs()
            {
                return _db.ProductGraphs;
            }

            public IEnumerable<BasicGraph> GetStoreGraphs()
            {
                return _db.StoreGraphs;
            }

            public IEnumerable<BasicGraph> GetTransactionGraphs()
            {
                return _db.TransactionsGraphs;
            }

            public IEnumerable<BasicGraph> GetAllGraphs()
            {
                return GetCategoryGraphs().ToList().Concat
                    (GetProductGraphs().ToList().Concat
                    (GetStoreGraphs().ToList().Concat
                    (GetTransactionGraphs())));
            }


            public void DeleteGraph(BasicGraph graph)
            {
                if (graph is CategoryGraph)
                {
                    _db.CategoryGraphs.Remove(graph as CategoryGraph);
                }
                else if (graph is ProductGraph)
                {
                    _db.ProductGraphs.Remove(graph as ProductGraph);
                }
                else if (graph is StoreGraph)
                {
                    _db.StoreGraphs.Remove(graph as StoreGraph);
                }
                else if (graph is ShoppingCartGraph)
                {
                    _db.TransactionsGraphs.Remove(graph as ShoppingCartGraph);
                }
                else
                {
                    throw new SystemException();
                }
                _db.SaveChanges();
            }


            private IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph<T>(BasicGraph graph, IEnumerable<T> items, Func<T, IEnumerable<ProductTransaction>> getProductTransactions, Func<T, int> getKey)
            {
                (DateTime endDate, DateTime startDate) = GetEndAndStartDates(graph.EndDate, graph.StartDate, graph.PastTimeType, graph.PastTimeAmount);
                AmountOrCost amountOrCost = graph.AmountOrCost;
                TimeType aggregationTimeType = graph.AggregationTimeType;



                var dailyCategoryGroups =
                    from item in items
                    group getProductTransactions(item) by getKey(item) into newGroup1
                    from newGroup2 in
                            (from productTransactionCollection in newGroup1
                             from productTransaction in productTransactionCollection
                             where productTransaction.Transaction.DateTime.InRange(startDate.Date, endDate.Date)
                             group productTransaction by GetTimeType(productTransaction.Transaction.DateTime, aggregationTimeType))
                    group newGroup2 by newGroup1.Key;


                IEnumerable<int> xCollection = GetXcollectios(startDate, endDate, aggregationTimeType);
                IEnumerable<int> keyCollection = items.Select(getKey);
                return GetGroupsPoints(dailyCategoryGroups, amountOrCost, keyCollection, xCollection);
            }

            private (DateTime, DateTime) GetEndAndStartDates(DateTime? endDate, DateTime? startDate, TimeType? pastTimeType, int? pastTimeAmount)
            {
                if (startDate == null && endDate == null)
                    return (DateTime.Now, AddPastTime(pastTimeType.Value, pastTimeAmount.Value));
                return (endDate.Value, startDate.Value);
            }

            private DateTime AddPastTime(TimeType PastTimeType, int pastTimeAmount)
            {
                pastTimeAmount = (-1) * (pastTimeAmount);
                switch (PastTimeType)
                {
                    case TimeType.Day:
                        return DateTime.Now.AddDays(pastTimeAmount);
                        break;
                    case TimeType.Week:
                        return DateTime.Now.AddDays(pastTimeAmount * 7);
                        break;
                    case TimeType.Month:
                        return DateTime.Now.AddMonths(pastTimeAmount);
                        break;
                    case TimeType.Year:
                        return DateTime.Now.AddYears(pastTimeAmount);
                        break;
                    default:
                        throw new ArgumentException("TimeType not initialized properly");
                        break;
                }
            }

            private IEnumerable<int> GetXcollectios(DateTime StartDate, DateTime EndDate, TimeType aggregationTimeType)
            {
                int startKey = GetTimeType(StartDate, aggregationTimeType);
                int endKey = GetTimeType(EndDate, aggregationTimeType);
                while (startKey <= endKey)
                {
                    yield return startKey;
                    startKey += 1;
                }
            }

            private int GetTimeType(DateTime dateTime, TimeType timeType)
            {
                switch (timeType)
                {
                    case TimeType.Day:
                        return dateTime.DayOfYear;
                        break;
                    case TimeType.Week:
                        return dateTime.DayOfYear/7;
                        break;
                    case TimeType.Month:
                        return dateTime.Month;
                        break;
                    case TimeType.Year:
                        return dateTime.Year;
                        break;
                    default:
                        throw new ArgumentException("TimeType not initialized properly");
                        break;
                }
            }

            public IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph(CategoryGraph categoryGraph)
            {
                return AnalyzeGraph(categoryGraph,
                    categoryGraph.Categories,
                    item => item.Products.Select(p => p.ProductTransactions).SelectMany(p => p),
                    item => (int)item.Id);
            }

            public IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph(ProductGraph productGraph)
            {
                return AnalyzeGraph(productGraph,
                    productGraph.Products,
                    item => item.ProductTransactions,
                    item => (int)item.Id);
            }

            public IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph(StoreGraph storeGraph)
            {
                return AnalyzeGraph(storeGraph,
                        storeGraph.Stores,
                        item => item.ProductTransaction,
                        item => (int)item.Id);
            }

            public IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph(TransactionsGraph transactionsGraph)
            {
                return AnalyzeGraph(transactionsGraph,
                                    new[] { 1 },
                                    item => _db.ProductTransactions,
                                    item => 1); ;
            }

            private Dictionary<int, IEnumerable<(double, double)>> GetGroupsPoints(IEnumerable<IGrouping<int, IGrouping<int, ProductTransaction>>> groupingGroups, AmountOrCost amountOrCost, IEnumerable<int> keyCollection, IEnumerable<int> xCollection)
            {
                Dictionary<int, IEnumerable<(double, double)>> analyzeGraph = new Dictionary<int, IEnumerable<(double, double)>>();
                keyCollection.ToList().ForEach(key => analyzeGraph.Add(key, xCollection.Select(x => ((double)x, 0d))));
                foreach (var superGroup in groupingGroups)
                {
                    Dictionary<double, double> points = new Dictionary<double, double>();
                    xCollection.ToList().ForEach(x => points.Add(x, 0));
                    foreach (var subGroup in superGroup)
                    {
                        double temp = 0;
                        foreach (var producrTransaction in subGroup)
                        {
                            switch (amountOrCost)
                            {
                                case AmountOrCost.Amount:
                                    temp += (producrTransaction.Amount);
                                    break;
                                case AmountOrCost.Cost:
                                    temp += (producrTransaction.UnitPrice * producrTransaction.Amount);
                                    break;
                                default:
                                    break;
                            }
                        }
                        points[subGroup.Key] = temp;
                    }
                    analyzeGraph[superGroup.Key] = points.Select(item => (item.Key, item.Value));
                }
                return analyzeGraph;
            }


        }
    }
}
