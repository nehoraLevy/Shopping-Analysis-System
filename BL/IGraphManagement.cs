using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public interface IGraphManagement
    {
        
        void AddGraph(CategoryGraph categoryGraph);

        
        void AddGraph(ProductGraph productGraph);

                void AddGraph(StoreGraph storeGraph);

                void AddGraph(ShoppingCartGraph transactionsGraph);

            void DeleteGraph(BasicGraph graph);
                IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph(CategoryGraph categoryGraph);

                IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph(ProductGraph productGraph);

                IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph(StoreGraph storeGraph);

                IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph(ShoppingCartGraph transactionsGraph);

                IEnumerable<BasicGraph> GetCategoryGraphs();

              IEnumerable<BasicGraph> GetProductGraphs();

                IEnumerable<BasicGraph> GetStoreGraphs();

                IEnumerable<BasicGraph> GetShoppingCartGraphs();
    }
}


