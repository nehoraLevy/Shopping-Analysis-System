using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IQRCodeFetcher
    {
        
        IEnumerable<IQRcode> GetQRCode();

       
        void DeleteQRcode(params string[] qrCodeFilesNamesToDelete);
    }
}
