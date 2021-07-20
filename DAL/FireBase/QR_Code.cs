using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace DAL.FireBase
{
    public class QR_Code
    {
        // message to check git
        public async static Task pictureFromFireBase()
        {
            var stream = File.Open(@"D:\STAM.jpg", FileMode.Open);//הורדתי קצת כי הסתרים זה המקום שבו שמים את ה טאסק 
            // Construct FirebaseStorage with path to where you want to upload the file and put it there
            var task = new FirebaseStorage("shoppingproject-92d77.appspot.com").Child("STAM2.jpg").PutAsync(stream);
            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress:  { e.Percentage} % ");
            // Await the task to wait until upload is completed and get the download url
            var downloadUrl =  await task;
            Console.WriteLine(downloadUrl);

        }

        
        private static void showDetails(string downloadUrl)
        {
            string imageUrl = downloadUrl;
            // Install-Package ZXing.Net -Version 0.16.5
            var client = new WebClient();
            var stream = client.OpenRead(imageUrl);
            if (stream == null) return;
            var bitmap = new Bitmap(stream);
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            Console.WriteLine(result.Text);
            Console.ReadLine();
        }
    }
}
