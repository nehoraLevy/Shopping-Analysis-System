using System;

namespace DAL_test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(DateTime.Now.DayOfYear);

            DAL.FireBase.QR_Code.pictureToFireBase();
            //DAL.FireBase.QR_Code.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingproject-92d77.appspot.com/o/STAM2.jpg?alt=media&token=3c7bab93-2db0-40a5-8bc2-bc57963c7c19");
            Console.ReadLine();
        }
    }
}
