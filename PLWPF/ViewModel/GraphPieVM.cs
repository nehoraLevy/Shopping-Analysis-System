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
            
            filterPie("day", "Category"); //to the change "category"
        }

        private String filter;
        public String Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                filterPie(Filter, "Category"); //to change 
            }
        }
        public void filterPie(String time, string filter)
        {
            List<ChartValues<double>> values = new List<ChartValues<double>>();
            int counterRami = 1;
            int counterOsher = 2;

            foreach (var v in ShoppingCartModel.shoppingCarts)
            {
                if (v.Store.Name.Contains("Rami Levy"))
                {
                    counterRami += 1;
                }
                else if(v.Store.Name.Contains("Osher Ad"))
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
            /*
            values.Add(new ChartValues<double> { 3 });
            values.Add(new ChartValues<double> { 6 });
            values.Add(new ChartValues<double> { 4 });
            values.Add(new ChartValues<double> { 9 });
            values.Add(new ChartValues<double> { 22 });
            values.Add(new ChartValues<double> { 13 });
            values.Add(new ChartValues<double> { 2 });
            values.Add(new ChartValues<double> { 3 });*/
            /*
            foreach (var v in ShoppingCartModel.shoppingCarts)
            {
                foreach( var pt in v.ProductTransactions)
                {
                    pt.Product.Category.Name.Contains("")
                }


            }*/
            
            /*
            _pieCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Milk Products",
                    Values = values[0],
                    PushOut = 15,
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
            };*/

            /*
            BE.CategoryGraph categoryGraph = new BE.CategoryGraph();
            categoryGraph.Id = 7;
            categoryGraph.Categories =categoryVM.cm.CategoriesList;
            categoryGraph.Description = "stam";
            categoryGraph.Title = "test pie";
            categoryGraph.EndDate = DateTime.MinValue;
            categoryGraph.StartDate = DateTime.Now;
            categoryGraph.PastTimeAmount = 7;
            categoryGraph.AmountOrCost = BE.AmountOrCost.Amount; //to change
            categoryGraph.GraphType = BE.GraphType.Pie;
            categoryGraph.TimeType = BE.TimeType.Day;//to chane to )Enum.Parse(typeof(string), time);

            //graphsModel.AddGraph(categoryGraph);
            */

        }
    }
}
