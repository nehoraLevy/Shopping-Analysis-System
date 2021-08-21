using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLWPF.ViewModel
{
    public class RuleVM
    {
        public string Products { get; set; }
        public string GoesWith { get; set; }
        public string Probablity { get; set; }

        public RuleVM(IMyAssociationRule rule)
        {
            Products = string.Join(", ", rule.Product.Select(p => p.Name));
            GoesWith = string.Join(", ", rule.GoesWith.Select(p => p.Name));
            Probablity = rule.Probability.ToString("P");
        }
    }
}
