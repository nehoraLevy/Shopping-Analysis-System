using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
namespace PLWPF.Model
{
    public class GraphsModel
    {
        IBL _bl;
        IGraphManagement _graphManagement;

        public GraphsModel()
        {
            _bl = new BL.BLogic();
            _graphManagement = _bl.GraphManagement;
        }

        public void AddGraph(CategoryGraph categoryGraph)
        {
            _graphManagement.AddGraph(categoryGraph);
        }

        public void AddGraph(ProductGraph productGraph)
        {
            _graphManagement.AddGraph(productGraph);
        }

        public void AddGraph(StoreGraph storeGraph)
        {
            _graphManagement.AddGraph(storeGraph);
        }

        public void AddGraph(ShoppingCartGraph transactionsGraph)
        {
            _graphManagement.AddGraph(transactionsGraph);
        }

        public IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph(CategoryGraph categoryGraph)
        {
            return _graphManagement.AnalyzeGraph(categoryGraph);
        }

        public IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph(ProductGraph productGraph)
        {
            return _graphManagement.AnalyzeGraph(productGraph);
        }

        public IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph(StoreGraph storeGraph)
        {
            return _graphManagement.AnalyzeGraph(storeGraph);
        }

        public IReadOnlyDictionary<int, IEnumerable<(double, double)>> AnalyzeGraph(ShoppingCartGraph transactionsGraph)
        {
            return _graphManagement.AnalyzeGraph(transactionsGraph);
        }

        public void DeleteGraph(BasicGraph graph)
        {
            _graphManagement.DeleteGraph(graph);
        }

        public IEnumerable<BasicGraph> GetCategoryGraphs()
        {
            return _graphManagement.GetCategoryGraphs();
        }

        public IEnumerable<BasicGraph> GetProductGraphs()
        {
            return _graphManagement.GetProductGraphs();
        }

        public IEnumerable<BasicGraph> GetStoreGraphs()
        {
            return _graphManagement.GetStoreGraphs();
        }

        public IEnumerable<BasicGraph> GetTransactionGraphs()
        {
            return _graphManagement.GetShoppingCartGraphs();
        }

    }
}
