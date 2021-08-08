using BL.associationRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public interface IBL
    {
        IAssociationProductAnalysis AssosiationProductsAnalysis { get; }
        IDataManagement DataManagement { get; }
        IGraphManagement GraphManagement { get; }
        //ITransactionAnalysis TransactionAnalysis { get; }
    }
}
