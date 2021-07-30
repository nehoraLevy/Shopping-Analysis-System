using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public interface IMyAssociationRule
    {

        IEnumerable<Product> GoesWith { get; set; }
        double Probability { get; set; }
        IEnumerable<Product> Product { get; set; }

    }
}
