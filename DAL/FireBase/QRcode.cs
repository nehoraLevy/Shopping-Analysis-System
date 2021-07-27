using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.FireBase
{
    internal class QRcode : IQRcode
    {
        public byte[] ImageStream { get; internal set; }
        public string FileName { get; internal set; }
    }
}
