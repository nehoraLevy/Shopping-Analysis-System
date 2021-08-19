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
        public ShoppingCartModel scm;
        public SeriesCollection PieCollection
        {
            get { return _pieCollection; }
        }

        public GraphPieVM(String id)
        {
            graphsModel = new GraphsModel();
            Id = id;

            filterPiebyStores("day", "Category"); //to the change "category"
        }

        private String filter;
        public String Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                filterPiebyStores(Filter, "Store"); //to change 
            }
        }
        public void filterPiebyStores(String time, string filter)
        {
            List<ChartValues<double>> values = new List<ChartValues<double>>();
            int counterRami = 0;
            int counterOsher = 0;
            scm = new ShoppingCartModel();
            foreach (var v in scm._dataManagement.GetShoppingCarts())
            {
                if (v.Store.Name.Contains("Rami Levy"))
                {
                    counterRami += 1;
                }
                else if (v.Store.Name.Contains("Osher Ad"))
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





        public void filterPiebyCategories(String time, string filter)
        {
            List<ChartValues<double>> values = new List<ChartValues<double>>();
            int counterMilk = 0;
            int counterFruit = 0;
            int counterFish = 0;
            int counterCanned = 0;
            int counterCooking = 0;
            int countersweets = 0;
            int counterDrinks = 0;
            int counterToiletery = 0;
            scm = new ShoppingCartModel();
            foreach (var v in scm._dataManagement.GetShoppingCarts())
            {
                foreach (var p in v.ProductTransactions)
                {
                    foreach (var t in scm._dataManagement.GetCategories())
                    {
                        if (t.Name == "milk Products")
                        {
                            if (t.Products.Contains(p.Product))
                                counterMilk += 1;
                        }
                        else if (t.Name == "Fruits and Vegetable")
                        {
                            if (t.Products.Contains(p.Product))
                                counterFruit += 1;
                        }
                        else if (t.Name == "Fish and Meat")
                        {
                            if (t.Products.Contains(p.Product))
                                counterFish += 1;
                        }
                        else if (t.Name == "Canned food")
                        {
                            if (t.Products.Contains(p.Product))
                                counterCanned += 1;
                        }
                        else if (t.Name == "Cooking and Baking")
                        {
                            if (t.Products.Contains(p.Product))
                                counterCooking += 1;
                        }
                        else if (t.Name == "Legumes and sweets ")
                        {
                            if (t.Products.Contains(p.Product))
                                countersweets += 1;
                        }
                        else if (t.Name == "Drinks")
                        {
                            if (t.Products.Contains(p.Product))
                                counterDrinks += 1;
                        }
                        else if (t.Name == "Home maintenance and Toiletries ")
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

