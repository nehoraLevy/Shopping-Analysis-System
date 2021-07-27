using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IQR_deCode
    {
        
        IEnumerable<IQRcode> GetQRCode();

       
        void DeleteQRcode(params string[] qrCodeFilesNamesToDelete);
    }
}
