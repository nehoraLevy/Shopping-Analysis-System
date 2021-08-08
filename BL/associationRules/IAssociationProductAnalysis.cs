using System;
using System.Collections.Generic;
using System.Text;

namespace BL.associationRules
{
    public interface IAssociationProductAnalysis
    {

            void CreateShopingListRecommendation(string path);

            IEnumerable<IMyAssociationRule> GetAssosiatonRules();

    }
}

