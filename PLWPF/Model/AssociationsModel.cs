using System;
using System.Collections.Generic;
using System.Text;
using BL;
using BL.associationRules;

namespace PLWPF.Model
{
    public class AssociationsModel
    {
        IBL _bl;
        IAssociationProductAnalysis _assosiationAnalysis;

        public IEnumerable<IMyAssociationRule> AssosiatonRules => _assosiationAnalysis.GetAssosiatonRules();

        public AssociationsModel()
        {
            _bl = new BL.BLogic();
            _assosiationAnalysis = _bl.AssosiationProductsAnalysis;
        }

        public void CreateShopingListRecommendation(string path)
        {
            _assosiationAnalysis.CreateShopingListRecommendation(path);
        }
    }
}
