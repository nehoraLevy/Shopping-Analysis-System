using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public interface IDataManagement
    {
        public IEnumerable<Product> GetProducts(string str = "");

        public IEnumerable<Category> GetCategories(string str = "");


        public IEnumerable<ShoppingCart> GetShoppingCartbyDate(DateTime date);


        public IEnumerable<ShoppingCart> GetShoppingCarts(DateTime? startDate = null, DateTime? endDate = null, IEnumerable<Store> stores = null, IEnumerable<Product> products = null, IEnumerable<Category> categories = null);


        public IEnumerable<Store> GetStores(string str = "");

        public void AddCategory(Category c);

        public void DeleteCategory(Category c);

        public void UpdateCategory(Category c);
        /*we add product and update her
         ctegory by create new category similer 
        to basic category adding the new product
        and replace the basic category*/
        public void AddProduct(Product p);

        public void DeleteProduct(Product p);

        public void AddShoppingCart(ShoppingCart s);

        public void DeleteShoppingCart(ShoppingCart s);
        
        public void UpdateShoppingCart(ShoppingCart s);
        public void AddSore(Store s);

        public void DeleteSore(Store s);

        public void UpdateSore(Store s);

        public void addUser(User user);


        public bool CheckId(int? id);


        public int? CheckUser(BE.User user);


            /*
             * אולי להוסיף החלפת סיסמה ליוזר
             */
        }
    }






