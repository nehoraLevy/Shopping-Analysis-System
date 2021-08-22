using System;
using System.Collections.Generic;
using System.Text;

namespace BL.associationRules
{
    public interface IAssociationProductAnalysis
    {

            string[] CreateShopingListRecommendation(string path);

            IEnumerable<IMyAssociationRule> GetAssosiatonRules();

    }
}

