using System;

namespace DAL_test
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL.FireBase.QR_deCode.pictureToFireBase("STAM.jpg");
            //DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingproject-92d77.appspot.com/o/STAM2.jpg?alt=media&token=63c0af22-d92c-457f-bf4d-1b375cbb8d96");
            Console.ReadLine();
        }
    }
}
