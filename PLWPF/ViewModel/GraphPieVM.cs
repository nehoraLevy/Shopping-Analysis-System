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

        public String Id { get; set; }
        //collection of the data in the pie
        private ObservableCollection<KeyValuePair<string, BE.Category>> _pieCollection;
        public ObservableCollection<KeyValuePair<string, BE.Category>> PieCollection
        {
            get { return _pieCollection; }
        }

        public GraphPieVM(String id)
        {
            graphsModel = new GraphsModel();
            Id = id;
            _pieCollection = new ObservableCollection<KeyValuePair<string, BE.Category>>();
            filterPie("day", "Category"); //to the change "category"
        }

        private String filter;
        public String Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                filterPie(Filter, "Category");
            }
        }
        private void filterPie(String time, string filter)
        {
            int counter = PieCollection.Count;
            for (int i = counter; i > 0; i--)
            {
                PieCollection.Remove(PieCollection[i - 1]);
            }


            BE.CategoryGraph categoryGraph = new BE.CategoryGraph();
            categoryGraph.Categories = new List<BE.Category>();
            categoryGraph.AmountOrCost = BE.AmountOrCost.Amount; //to change
            categoryGraph.GraphType = BE.GraphType.Pie;
            categoryGraph.TimeType = BE.TimeType.Day; //to change
            PieCollection.Add(new KeyValuePair<string, BE.Category>("milk Products", categoryGraph.Categories[0]));
            PieCollection.Add(new KeyValuePair<string, BE.Category>("Fruits and Vegetable", categoryGraph.Categories[1]));
            PieCollection.Add(new KeyValuePair<string, BE.Category>("Fish and Meat", categoryGraph.Categories[2]));
            PieCollection.Add(new KeyValuePair<string, BE.Category>("Canned food", categoryGraph.Categories[3]));
            PieCollection.Add(new KeyValuePair<string, BE.Category>("Cooking and Baking", categoryGraph.Categories[4]));
            PieCollection.Add(new KeyValuePair<string, BE.Category>("Legumes and sweets ", categoryGraph.Categories[5]));
            PieCollection.Add(new KeyValuePair<string, BE.Category>("Drinks", categoryGraph.Categories[6]));
            PieCollection.Add(new KeyValuePair<string, BE.Category>("Home maintenance and Toiletries ", categoryGraph.Categories[7]));
        }
    }
}
