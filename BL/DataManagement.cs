using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BL
{
    public class DataManagement:IDataManagement
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

        public IEnumerable<Category> GetCategories(string str ="")
        {
            return _db.Categories.Where(c => c.Name.Contains(str));
        }


        public IEnumerable<ShoppingCart> GetShoppingCartbyDate(DateTime date)
        {
            return _db.ShoppingCarts.Where(s => s.BuyDate == date);
        }

        public IEnumerable<ShoppingCart> GetShoppingCarts(DateTime? startDate = null, DateTime? endDate = null, IEnumerable<Store> stores = null, IEnumerable<Product> products = null, IEnumerable<Category> categories = null)
        {
            IEnumerable<ShoppingCart> shoppingCarts = _db.ShoppingCarts.AsNoTracking();
            if (startDate.HasValue) shoppingCarts = shoppingCarts.Where(t => t.BuyDate.Date >= startDate.Value);
            if (endDate.HasValue) shoppingCarts = shoppingCarts.Where(t => t.BuyDate.Date <= endDate.Value);
            if (stores != null)
            {
                shoppingCarts = from t in shoppingCarts
                                from pt in t.ProductTransactions
                               where stores.Select(s => s.Id).Contains(pt.Store.Id)
                               select t;
            }
            if (products != null)
            {
                shoppingCarts = from t in shoppingCarts
                                from pt in t.ProductTransactions
                               where products.Select(p => p.Id).Contains(pt.Product.Id)
                               select t;
            }
            if (categories != null)
            {
                shoppingCarts = from t in shoppingCarts
                                from pt in t.ProductTransactions
                               where categories.Select(c => c.Id).Contains(pt.Product.Category.Id)
                               select t;
            }
            return shoppingCarts;
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

        public void cleanCategory()
        {
           
            foreach (var i in _db.Categories)
                _db.Categories.Remove(i);
            _db.SaveChanges();

        }

        public void cleanStore()
        {

            foreach (var i in _db.Stores)
                _db.Stores.Remove(i);
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

        public void addUser(User user)
        {
            if (CheckId(user.Id))//if the user exist on database
                throw new Exception("The user exist on system");
            else
            {
                    _db.Users.Add(user);
                    _db.SaveChanges();
            }
        }

        public bool CheckEmail(string? email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
  
        public bool CheckId(int? id)
        {
                foreach (var item in _db.Users)
                {
                    if (item.Id == id)
                        return true;
                }
            return false;
        }


        public int? CheckUser(BE.User user)
        {

                foreach (var item in _db.Users)
                {
                    if (item.Id == user.Id && item.Password == user.Password)
                        return item.Id;
                }
            return null;
        }


        /*
         * אולי להוסיף החלפת סיסמה ליוזר
         */





    }
}




