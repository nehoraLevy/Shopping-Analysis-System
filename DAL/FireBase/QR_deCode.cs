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
    public class QR_deCode:IQR_deCode
    {
        //להסתכל על QRCodeFetcher  של אושר 

        // message to check git
        public async static void pictureToFireBase(string name)
        {
            string str = "C:\\Users\\levy\\Desktop\\";
            string url = string.Concat(str, name);
            var stream = File.OpenRead(url);
            // Construct FirebaseStorage with path to where you want to upload the file and put it there
            var task = new FirebaseStorage("shoppingproject-92d77.appspot.com").Child(name).PutAsync(stream);
            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress:  { e.Percentage} % ");
            // Await the task to wait until upload is completed and get the download url
            var downloadUrl =  await task;
            Console.WriteLine(downloadUrl);
        }

        public static void showDetails(string downloadUrl)
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

        public void DeleteQRcode(params string[] qrCodeFilesNamesToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IQRcode> GetQRCode()
        {
            throw new NotImplementedException();
        }
    }
}
