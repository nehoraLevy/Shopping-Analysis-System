using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDb : IDisposable
    {
        IDbCollection<QRcode_data> QRDatas { get; }
        IDbCollection<Product> Products { get; }
        IDbCollection<Category> Categories { get; }
        IDbCollection<Store> Stores { get; }
        IDbCollection<ShoppingCart> ShoppingCarts { get; }
        IDbCollection<ShoppingCartGraph> ShoppingCartGraphs { get; }
        IDbCollection<ProductTransaction> ProductTransactions { get; }
        IDbCollection<StoreGraph> StoreGraphs { get; }
        IDbCollection<ProductGraph> ProductGraphs { get; }
        IDbCollection<CategoryGraph> CategoryGraphs { get; }
        IDbCollection<User> Users { get; }
        void SaveChanges();
    }
}
