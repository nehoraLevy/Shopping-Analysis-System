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
        private ObservableCollection<KeyValuePair<string, float>> _pieCollection;
        public ObservableCollection<KeyValuePair<string, float>> PieCollection
        {
            get { return _pieCollection; }
        }

        public GraphPieVM(String id)
        {
            graphsModel = new GraphsModel();
            Id = id;
            _pieCollection = new ObservableCollection<KeyValuePair<string, float>>();
            filterPie("day", "Category");
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
            categoryGraph.AmountOrCost = BE.AmountOrCost.Amount;
            categoryGraph.GraphType = BE.GraphType.Pie;
            //categoryGraph.TimeType = time;
            PieCollection.Add(new KeyValuePair<string, float>("milk Products", categoryGraph.Categories);
            PieCollection.Add(new KeyValuePair<string, float>("Fruits and Vegetable", categoryGraph.Categories[1]));
            PieCollection.Add(new KeyValuePair<string, float>("Fish and Meat", categoryGraph.Categories[2]));
            PieCollection.Add(new KeyValuePair<string, float>("Canned food", categoryGraph.Categories[3]));
            PieCollection.Add(new KeyValuePair<string, float>("Cooking and Baking", categoryGraph.Categories[4]));
            PieCollection.Add(new KeyValuePair<string, float>("Legumes and sweets ", categoryGraph.Categories[5]));
            PieCollection.Add(new KeyValuePair<string, float>("Drinks", categoryGraph.Categories[6]));
            PieCollection.Add(new KeyValuePair<string, float>("Home maintenance and Toiletries ", categoryGraph.Categories[7]));
        }
    }
}
