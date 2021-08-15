using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL_test
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            DAL.FireBase.QR_deCode.PictureToFireBase("STAM.jpg");
            Console.WriteLine("success");
            
            //DAL.FireBase.QR_deCode.showDetails("");
            Console.ReadLine();
            */
            /*
            DataManagement bl =new DataManagement();
            bl.cleanProduct();*/
            var db = new DAL.DalFactory().GetDb();
            if(db.Categories.Count()==0)
            {
                Console.WriteLine(db.Categories.Count());
                var categories = new[] { "מוצרי חלב", "פירות וירקות", "בשר ודגים", "שימורים", "בישול ואפייה", "קטניות ומתוקים", "משקאות", "אחזקת הבית וטואלטיקה" };
                foreach (var i in categories)
                    db.Categories.Add(new BE.Category { Name = i });
                db.SaveChanges();
            }


            if (db.Products.Count() == 0)
            {
                Console.WriteLine(db.Products.Count());
                var products = new[] { "חלב", "גבינה"};
                var prices = new[] { 5, 7 };
                var images = new[] { "images\\milk.png", "images\\whitecheese.jpg" };
                var description = new[] { "1 ליטר חלב מפוסטר", "250 גרם גבינה לבנה" };
               
                for(int i=0; i<products.Length; i++)
                    db.Products.Add(new BE.Product { Name = products[i], Category=db.Categories.Where(c=>c.Name.Contains("מוצרי חלב")).FirstOrDefault(), Price=prices[i], ImageFileName=images[i], Description=description[i] });
                db.SaveChanges();
            }
            Console.WriteLine(db.Categories.Count());
            /*
            foreach (var v in db.Categories)
            {
                if (v.Name.Contains("מוצרי חלב"))
                {
                    v.Products = new List<Product>();
                    v.Products.Add(db.Products.Where(d => d.Category.Name.Contains("מוצרי חלב")).FirstOrDefault());
                }
            }*/

        }
    }
}
