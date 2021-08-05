using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    internal class MyAssociatonRule : IMyAssociationRule
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Product> GoesWith { get; set; }
        public double Probability { get; set; }
      

        public MyAssociatonRule(IEnumerable<Product> product, IEnumerable<Product> goesWith, double probability)
        {
            Product = product;
            GoesWith = goesWith;
            //the products that matchs the selected product with apriory algorithm 
            Probability = probability;
        }
    }
}

