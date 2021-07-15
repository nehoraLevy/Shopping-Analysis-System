using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    interface IAssociationRule
    {

        IEnumerable<Product> GoesWith { get; set; }
        double Probability { get; set; }
        IEnumerable<Product> Product { get; set; }

    }
}
