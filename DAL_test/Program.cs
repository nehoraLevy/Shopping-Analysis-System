using System;

namespace DAL_test
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL.FireBase.QR_deCode.pictureToFireBase("Apple.png");
            //DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingproject-92d77.appspot.com/o/Apple.png?alt=media&token=ec959628-2747-459b-a1fc-06b332f471d9");
            Console.ReadLine();
        }
    }
}
