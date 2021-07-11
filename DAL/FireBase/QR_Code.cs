using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Firebase.Storage;

namespace DAL.FireBase
{
    public class QR_Code
    {
        // message to check git
        public async static Task pictureFromFireBase()
        {
            var stream = File.Open(@"C:\Users\batya\OneDrive\שולחן העבודה\Shopping_project_final\QR_codes\butter_200_8.png", FileMode.Open);//הורדתי קצת כי הסתרים זה המקום שבו שמים את ה טאסק 
            // Construct FirebaseStorage with path to where you want to upload the file and put it there
            Console.WriteLine("aaa");
            var task = new FirebaseStorage("gs://shoppingproject-92d77.appspot.com/QR_codes").Child("aa").PutAsync(stream);
            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress:  { e.Percentage} % ");
            // Await the task to wait until upload is completed and get the download url
            var downloadUrl =  await task;
            Console.WriteLine(downloadUrl);

        }
    }
}
