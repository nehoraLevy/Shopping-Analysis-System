using LiveCharts;
using PLWPF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLWPF.ViewModel
{
    public class GraphLineVM
    {

        GraphsModel graphsModel;

        public String Id { get; set; }
        //collection of the data in the pie
        private SeriesCollection _lineCollection;
        public SeriesCollection LineCollection
        {
            get { return _lineCollection; }
        }

        public GraphLineVM(String id)
        {
            graphsModel = new GraphsModel();
            Id = id;

            filterPie("day", "Category"); //to change
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

        }
    }
}
