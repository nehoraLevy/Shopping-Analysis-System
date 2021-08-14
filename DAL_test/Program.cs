using System;
using System.Linq;


namespace DAL_test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DAL.FireBase.QR_deCode.pictureToFireBase("cookies.png");
            /*
            //DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingproject-92d77.appspot.com/o/Apple.png?alt=media&token=ec959628-2747-459b-a1fc-06b332f471d9");
            Console.ReadLine();

            var db = new DAL.DalFactory().GetDb();
            var categories = new[] { "מוצרי חלב", "פירות וירקות", "בשר ודגים", "שימורים", "בישול ואפייה", "קטניות ומתוקים", "משקאות","אחזקת הבית וטואלטיקה" };
            foreach (var i in categories)
                db.Categories.Add(new BE.Category { Name = i });
            db.SaveChanges();
            Console.WriteLine(db.Categories.Count());
            db.Products.Add(new BE.Product { Name = "תפוח", ImageFileName = "", Category = (BE.Category)db.Categories.Where(c => c.Name == "מוצרי חלב"), BarCode= "https://firebasestorage.googleapis.com/v0/b/shoppingproject-92d77.appspot.com/o/Apple.png?alt=media&token=ec959628-2747-459b-a1fc-06b332f471d9" });

            BL.DataManagement bl=new BL.DataManagement();
            bl.cleanCategory();
            var db = new DAL.DalFactory().GetDb();
            if(db.Categories.Count()==0)
            {
                Console.WriteLine(db.Categories.Count());
                var categories = new[] { "מוצרי חלב", "פירות וירקות", "בשר ודגים", "שימורים", "בישול ואפייה", "קטניות ומתוקים", "משקאות", "אחזקת הבית וטואלטיקה" };
                foreach (var i in categories)
                    db.Categories.Add(new BE.Category { Name = i });
                db.SaveChanges();

            }
            Console.WriteLine(db.Categories.Count());*/

        }
    }
}
