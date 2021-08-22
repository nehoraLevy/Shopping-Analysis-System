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

        public string[] CreateShopingListRecommendation(string path)
        {
            return _assosiationAnalysis.CreateShopingListRecommendation(path);
        }
    }
}
