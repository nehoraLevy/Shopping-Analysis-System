﻿using System;
using System.Linq;

namespace DAL_test
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            DAL.FireBase.QR_deCode.pictureToFireBase("Apple.png");
            //DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingproject-92d77.appspot.com/o/Apple.png?alt=media&token=ec959628-2747-459b-a1fc-06b332f471d9");
            Console.ReadLine();*/

            var db = new DAL.DalFactory().GetDb();
            Console.WriteLine(db.Categories.Count());
            //var categories = new[] { "מוצרי חלב", "פירות וירקות", "בשר ודגים", "שימורים", "בישול ואפייה", "קטניות ומתוקים", "משקאות","אחזקת הבית וטואלטיקה" };
            //db.Categories.AddRange(categories.Select(n => new BE.Category { Name = n }));
            
          

            //Console.WriteLine(db.Categories.Select( c => c.Name));
        }
    }
}
