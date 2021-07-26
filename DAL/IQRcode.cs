using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IQRcode
    {
        string FileName { get; }
        byte[] ImageStream { get; }
    }
}
