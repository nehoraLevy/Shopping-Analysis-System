using LiveCharts;
using LiveCharts.Wpf;
using PLWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PLWPF.ViewModel
{
    public class GraphPieVM
    {

        public GraphsModel graphsModel;
        public CategoryVM categoryVM = new CategoryVM();
        public ShoppingCardVM shoppingCardVM = new ShoppingCardVM();

        public ShoppingCartModel scm;
        public String Id { get; set; }
        //collection of the data in the pie
        private SeriesCollection _pieCollection;
        public SeriesCollection PieCollection
        {
            get { return _pieCollection; }
        }

        public GraphPieVM(String id)
        {
            graphsModel = new GraphsModel();
            Id = id;

        }

        private String filterStore;
        public String FilterStore
        {
            get { return filterStore; }
            set
            {
                filterStore = value;
                filterPiebyStores(FilterStore); //to change 
            }
        }
        public void filterPiebyStores(String time)
        {
            List<ChartValues<double>> values = new List<ChartValues<double>>();
            int counterRami = 0;
            int counterOsher = 0;
            DateTime start= DateTime.Now;
            DateTime end= DateTime.Now;
            if(time=="day")
            {
                start = DateTime.Now.AddDays(-1);
                end = DateTime.Now;
            }
            else if (time == "week")
            {
                start = DateTime.Now.AddDays(-7);
                end = DateTime.Now;
            }
            else if (time== "month")
            {
                start = DateTime.Now.AddMonths(-1);
                end = DateTime.Now;
            }
            scm = new ShoppingCartModel();
            foreach (var v in scm._dataManagement.GetShoppingCarts())
            {
                if (v.Store.Name.Contains("Rami Levy") && v.BuyDate>= start&&v.BuyDate<=end)
                {
                    counterRami += 1;
                }
                else if (v.Store.Name.Contains("Osher Ad") && v.BuyDate >= start && v.BuyDate <= end)
                {
                    counterOsher += 1;
                }
            }
            values.Add(new ChartValues<double> { counterRami });
            values.Add(new ChartValues<double> { counterOsher });

            _pieCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Rami Levy",
                    Values = values[0],
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Osher Ad",
                    Values = values[1],
                    DataLabels = true,
                }
            };
            values.Add(new ChartValues<double> { 3 });
            values.Add(new ChartValues<double> { 6 });
            values.Add(new ChartValues<double> { 4 });
            values.Add(new ChartValues<double> { 9 });
            values.Add(new ChartValues<double> { 22 });
            values.Add(new ChartValues<double> { 13 });
            values.Add(new ChartValues<double> { 2 });
            values.Add(new ChartValues<double> { 3 });
        }





        public void filterPiebyCategories(String time)
        {
            List<ChartValues<double>> values = new List<ChartValues<double>>();
            int counterMilk = 1;
            int counterFruit = 2;
            int counterFish = 3;
            int counterCanned = 4;
            int counterCooking = 5;
            int countersweets = 6;
            int counterDrinks = 7;
            int counterToiletery = 8;
            scm = new ShoppingCartModel();
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            if (time == "day")
            {
                start = DateTime.Now.AddDays(-1);
                end = DateTime.Now;
            }
            else if (time == "week")
            {
                start = DateTime.Now.AddDays(-7);
                end = DateTime.Now;
            }
            else if (time == "month")
            {
                start = DateTime.Now.AddMonths(-1);
                end = DateTime.Now;
            }
            foreach (var v in scm._dataManagement.GetShoppingCarts())
            {
                foreach (var p in v.ProductTransactions)
                {
                    foreach (var t in scm._dataManagement.GetCategories())
                    {
                        if (t.Name == "milk Products" && v.BuyDate >= start && v.BuyDate <= end)
                        {
                            if (t.Products.Contains(p.Product))
                                counterMilk += 1;
                        }
                        else if (t.Name == "Fruits and Vegetable" && v.BuyDate >= start && v.BuyDate <= end)
                        {
                            if (t.Products.Contains(p.Product))
                                counterFruit += 1;
                        }
                        else if (t.Name == "Fish and Meat" && v.BuyDate >= start && v.BuyDate <= end)
                        {
                            if (t.Products.Contains(p.Product))
                                counterFish += 1;
                        }
                        else if (t.Name == "Canned food" && v.BuyDate >= start && v.BuyDate <= end)
                        {
                            if (t.Products.Contains(p.Product))
                                counterCanned += 1;
                        }
                        else if (t.Name == "Cooking and Baking" && v.BuyDate >= start && v.BuyDate <= end)
                        {
                            if (t.Products.Contains(p.Product))
                                counterCooking += 1;
                        }
                        else if (t.Name == "Legumes and sweets " && v.BuyDate >= start && v.BuyDate <= end)
                        {
                            if (t.Products.Contains(p.Product))
                                countersweets += 1;
                        }
                        else if (t.Name == "Drinks")
                        {
                            if (t.Products.Contains(p.Product))
                                counterDrinks += 1;
                        }
                        else if (t.Name == "Home maintenance and Toiletries " && v.BuyDate >= start && v.BuyDate <= end)
                        {
                            if (t.Products.Contains(p.Product))
                                counterToiletery += 1;
                        }
                    }

                }

                values.Add(new ChartValues<double> { counterMilk });
                values.Add(new ChartValues<double> { counterFruit });
                values.Add(new ChartValues<double> { counterFish });
                values.Add(new ChartValues<double> { counterCanned });
                values.Add(new ChartValues<double> { counterCooking });
                values.Add(new ChartValues<double> { countersweets });
                values.Add(new ChartValues<double> { counterDrinks });
                values.Add(new ChartValues<double> { counterToiletery });

                _pieCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "milk Products",
                    Values = values[0],
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Fruits and Vegetable",
                    Values = values[1],
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Fish and Meat",
                    Values = values[2],
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Canned food",
                    Values = values[3],
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Cooking and Baking",
                    Values = values[4],
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Legumes and sweets ",
                    Values = values[5],
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Drinks",
                    Values = values[6],
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Home maintenance and Toiletries ",
                    Values = values[7],
                    DataLabels = true,
                }
            };

                BE.CategoryGraph categoryGraph = new BE.CategoryGraph();
                categoryGraph.Id = 7;
                categoryGraph.Categories = categoryVM.cm.CategoriesList;
                categoryGraph.Description = "stam";
                categoryGraph.Title = "test pie";
                categoryGraph.EndDate = DateTime.MinValue;
                categoryGraph.StartDate = DateTime.Now;
                categoryGraph.PastTimeAmount = 7;
                categoryGraph.AmountOrCost = BE.AmountOrCost.Amount; //to change
                categoryGraph.GraphType = BE.GraphType.Pie;
                categoryGraph.TimeType = BE.TimeType.Day;//to chane to )Enum.Parse(typeof(string), time);

                //graphsModel.AddGraph(categoryGraph);


            }
        }
    }
}

