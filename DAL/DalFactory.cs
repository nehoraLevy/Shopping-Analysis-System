
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class DalFactory
    {
        private static IQR_deCode _qRCodeFetcher;
        private static IDb _db;
        // TODO: Remove static!!
        public IQR_deCode GetQRCodeFetcher()
        {
            if (_qRCodeFetcher is null)
            {
                _qRCodeFetcher = new FireBase.QR_deCode();
            }
            return _qRCodeFetcher;
        }
        public IDb GetDb()
        {
            if (_db is null)
            {
                _db = new EntityFramework.HomeEconomicContext();
            }
            return _db;
        }
    }
}
