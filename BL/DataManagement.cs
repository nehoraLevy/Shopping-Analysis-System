using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    class DataManagement
    {
        /*private IDb _db;
        

        public DataManagement()
        {
            _db = new DalFactory().GetDb();
        }*/
        //Getters

        public IEnumerable<Product> GetProducts(string str="")
        {
            return _db.Products.Where(c => c.Name.Contains(str));
        }

        public IEnumerable<Category> GetCategories(string str = "")
        {
            return _db.Categories.Where(c => c.Name.Contains(str));
        }


        public IEnumerable<ShoppingCart> GetShoppingCartbyDate(DateTime date)
        {
            return _db.ShoppingCarts.Where(s => s.BuyDate == date);
        }

        public IEnumerable<Category> GetShoppingCarts(string str = "")
        {
            return _db.ShoppingCarts.Where(c => c.Name.Contains(str));
        }

        public IEnumerable<Category> GetStores(string str = "")
        {
            return _db.Stores.Where(c => c.Name.Contains(str));
        }


        public void AddCategory(Category c)
        {
            if (_db.Categories.Where(c => c.Name.Contains(c.Name))!=null)
                throw (new ArgumentException("the category already exists."));
            if (c.Id==null || c.Name==null)
                throw (new ArgumentException("Category must have: Id, Name."));

            _db.Categories.Add(c);
            _db.SaveChanges();
        }

        public void DeleteCategory(Category c)
        {
            if (_db.Categories.Where(c => c.Name.Contains(c.Name)) == null)
                throw (new ArgumentException("the category not exists."));

            if (c.Id == null || c.Name == null)
                throw (new ArgumentException("Category must have: Id, Name."));

            _db.Categories.Remove(c);
            _db.SaveChanges();

        }

        public void UpdateCategory(Category c)
        {
            
            DeleteCategory(c);
            AddCategory(c);
        }
        /*we add product and update her
         ctegory by create new category similer 
        to basic category adding the new product
        and replace the basic category*/
        public void AddProduct(Product p)
        {
            if (_db.Products.Where(c => c.Name.Contains(c.Name)) != null)
                throw (new ArgumentException("the product already exists."));

            if (p.Id == null || p.Name == null)
                throw (new ArgumentException("Product must have: Id, Name."));
            _db.Products.Add(p);
            Category c = new Category(p.Category);
            c.Products.Add(p);
            UpdateCategory(c);
            _db.SaveChanges();

        }

        public void DeleteProduct(Product p)
        {
            if (_db.Categories.Where(c => c.Name.Contains(p.Name)) == null)
                throw (new ArgumentException("the Product not exists."));

            if (p.Id == null ||p.Name == null)
                throw (new ArgumentException("product must have: Id, Name."));

            _db.Categories.Remove(p);
            _db.SaveChanges();
        }

        public void UpdateProduct(Product p)
        {
            DeleteProduct(p);
            AddProduct(p);
        }

        public void AddShoppingCart(ShoppingCart s)
        {
            if (_db.ShoppingCarts.Where(c => c.Name.Contains(c.Name)) != null)
                throw (new ArgumentException("the ShoppingCart already exists."));

            if (s.Id == null || s.Name == null)
                throw (new ArgumentException("ShoppingCart must have: Id, Name."));
            _db.ShoppingCarts.Add(s);
            _db.SaveChanges();
        }

        public void DeleteShoppingCart(ShoppingCart s)
        {
            if (_db.ShoppingCarts.Where(c => c.Name.Contains(s.Name)) == null)
                throw (new ArgumentException("the ShoppingCart not exists."));

            if (s.Id == null)
                throw (new ArgumentException("ShoppingCart must have: Id."));

            _db.ShoppingCarts.Remove(s);
            _db.SaveChanges();
        }

        public void UpdateShoppingCart(ShoppingCart s)
        {
            DeleteShoppingCart(s);
            AddShoppingCart(s);
        }


        public void AddSore(Store s)
        {
            if (_db.Products.Where(c => c.Name.Contains(c.Name)) != null)
                throw (new ArgumentException("the product already exists."));

            if (s.Id == null || s.Name == null)
                throw (new ArgumentException("Product must have: Id, Name."));
            _db.Stores.Add(s);
            _db.SaveChanges();
        }

        public void DeleteSore(Store s)
        {
            if (_db.Stores.Where(c => c.Name.Contains(s.Name)) == null)
                throw (new ArgumentException("the Store  not exists."));

            if (s.Id == null || s.Name==null)
                throw (new ArgumentException("Store  must have: Id."));

            _db.ShoppingCarts.Remove(s);
            _db.SaveChanges();
        }

        public void UpdateSore(Store s)
        {
            DeleteSore(s);
            AddSore(s);
        }




    }
}
