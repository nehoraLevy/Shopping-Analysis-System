using System;

namespace DAL_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.DayOfYear);
            
            DAL.FireBase.QR_Code.pictureFromFireBase();
            Console.WriteLine("bbb");
            Console.ReadLine();
        }
    }
}
