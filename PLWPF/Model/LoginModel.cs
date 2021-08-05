using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL;

namespace PLWPF.Models
{
    //class that connect between view model to bl
    public class ModelLogin
    {
        public BL.IDataManagement dm;
        public ModelLogin()
        {
            dm = new BL.DataManagement();

        }
        /// <summary>
        ///check if user in data base
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int? CheckUser(BE.User user)
        {
            return dm.CheckUser(user);
        }
    }
}
