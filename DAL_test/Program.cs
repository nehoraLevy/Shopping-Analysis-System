using System;

namespace DAL_test
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL.FireBase.QR_deCode.pictureToFireBase("Apple.png");
            DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingproject-92d77.appspot.com/o/Apple.png?alt=media&token=1a7ff55e-b4b9-4cce-b548-0cb66113cc77");
            Console.ReadLine();
        }
    }
}
