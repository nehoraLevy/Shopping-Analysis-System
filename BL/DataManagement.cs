﻿using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    class DataManagement
    {
        private IDb _db;
        

        public DataManagement()
        {
            _db = new DalFactory().GetDb();
        }
        

        public IEnumerable<Product> GetProducts(string str="")
        {
            IEnumerable <Product>  prod= _db.Products.Where(c => c.Name.Contains(str));
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

        public IEnumerable<ShoppingCart> GetShoppingCarts()
        {

            return _db.ShoppingCarts;
        }

        public IEnumerable<Store> GetStores(string str = "")
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
            if (_db.Products.Where(c => c.Name.Contains(p.Name)) == null)
                throw (new ArgumentException("the Product not exists."));

            if (p.Id == null ||p.Name == null)
                throw (new ArgumentException("product must have: Id, Name."));

            _db.Products.Remove(p);
            _db.SaveChanges();
        }

        public void UpdateProduct(Product p)
        {
            DeleteProduct(p);
            AddProduct(p);
        }

        public void AddShoppingCart(ShoppingCart s)
        {
            if (_db.ShoppingCarts.Where(c => c.Id == s.Id) != null)
                throw (new ArgumentException("the ShoppingCart already exists."));

            if (s.Id == null) //|| s.Name == null
                throw (new ArgumentException("ShoppingCart must have: Id, Name."));
            _db.ShoppingCarts.Add(s);
            _db.SaveChanges();
        }

        public void DeleteShoppingCart(ShoppingCart s)
        {
            if (_db.ShoppingCarts.Where(c => c.Id == s.Id) == null)
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

            if ( s.Name == null) 
                throw (new ArgumentException("Product must have: Id, Name."));
            _db.Stores.Add(s);
            _db.SaveChanges();
        }

        public void DeleteSore(Store s)
        {
            if (_db.Stores.Where(c => c.Name.Contains(s.Name)) == null)
                throw (new ArgumentException("the Store  not exists."));

            if ( s.Name==null) 
                throw (new ArgumentException("Store  must have: Id."));

            _db.Stores.Remove(s);
            _db.SaveChanges();
        }

        public void UpdateSore(Store s)
        {
            DeleteSore(s);
            AddSore(s);
        }




    }
}



/**
 *  public IEnumerable<Transaction> GetTransactions(DateTime? startDate = null, DateTime? endDate = null, IEnumerable<Store> stores = null, IEnumerable<Product> products = null, IEnumerable<Category> categories = null)
        {
            IEnumerable<Transaction> transactions = _db.Transactions.AsNoTracking();
            if (startDate.HasValue) transactions = transactions.Where(t => t.DateTime.Date >= startDate.Value);
            if (endDate.HasValue) transactions = transactions.Where(t => t.DateTime.Date <= endDate.Value);
            if (stores != null)
            {
                transactions = from t in transactions
                               from pt in t.ProductTransactions
                               where stores.Select(s=>s.Id).Contains(pt.Store.Id)
                               select t;
            }
            if (products != null)
            {
                transactions = from t in transactions
                               from pt in t.ProductTransactions
                               where products.Select(p => p.Id).Contains(pt.Product.Id)
                               select t;
            }
            if (categories != null)
            {
                transactions = from t in transactions
                               from pt in t.ProductTransactions
                               where categories.Select(c => c.Id).Contains(pt.Product.Category.Id)
                               select t;
            }
            return transactions;
        }

        public void UpdateTransaction(Transaction transaction)
        {
            if (!_validation.Validate(transaction))
                throw (new ArgumentException("Error in transaction"));

            var oldTransaction = _db.Transactions.Single(t => t.Id == transaction.Id);
            oldTransaction.DateTime = transaction.DateTime;
            oldTransaction.ProductTransactions = transaction.ProductTransactions;
            _db.SaveChanges();
        }

        public void AddTransaction(Transaction transaction)
        {
            if (!_validation.Validate(transaction))
                throw (new ArgumentException("Error in transaction"));

            _db.Transactions.Add(transaction);
            _db.SaveChanges();
        }
    }
}*/
