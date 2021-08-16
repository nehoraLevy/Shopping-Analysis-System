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
       
        public async static void PictureToFireBase(string name)
        {
            var stream = File.OpenRead(@"C:\Users\batya\OneDrive\" + name);
            
            var task = new FirebaseStorage("shoppingprojectfinal.appspot.com")
            .Child(name)
            .PutAsync(stream);
            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress:{ e.Percentage} % ");
            // Await the task to wait until upload is completed and get the download url
            var downloadUrl = await task;
            Console.WriteLine(downloadUrl);

        }

        public static void showDetails(string downloadUrl,string imagePath)
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
            addTOProduct(result.Text,  imagePath);
            return;
        }
                
        public static void addTOQR(string qrCode, string imagePath)
        {
            string[] str=qrCode.Split(",");
            var db = new DAL.DalFactory().GetDb();
            if (db.Products.Where(c => c.Name.Contains(str[0]))!=null)
                return;
            db.QRDatas.Add(new BE.QRcode_data { Name = str[0], BarCode = str[1], Id = Int32.Parse(str[2]), Price = Int32.Parse(str[3]), Amount = Int32.Parse(str[3]), StoreName = db.Stores.First()  });
            addTOProduct(qrCode, imagePath);
            db.SaveChanges();
            return;

        }
        public static void addTOProduct(string qrCode, string imagePath)
        {
            string[] str = qrCode.Split(",");
            var db = new DAL.DalFactory().GetDb();
            if (db.Products.Where(c => c.Name.Contains(str[0])) != null)
                return;
            db.Products.Add(new BE.Product { Name = str[0], BarCode = str[1], Id = Int32.Parse(str[2]), Price = Int32.Parse(str[3]), AmountPerPiece = Int32.Parse(str[3]), ImageFileName =imagePath });
            db.SaveChanges();
            return;

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
