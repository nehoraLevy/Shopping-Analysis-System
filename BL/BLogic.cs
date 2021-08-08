using BL.associationRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class BLogic:IBL
    {
        public IAssociationProductAnalysis AssosiationProductsAnalysis { get; }
        public IDataManagement DataManagement { get; }
        public IGraphManagement GraphManagement { get; }


        public BLogic ()
        {

            AssosiationProductsAnalysis = new AssociationProductAnalysis();

            GraphManagement = new GraphManagement();

            DataManagement = new DataManagement();

        }
    }
}
