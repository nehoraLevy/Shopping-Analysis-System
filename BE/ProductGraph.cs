using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class ProductGraph: BasicGraph
    {
        private List<Product> _collection;
        /// <summary>
        /// The items to show graph for.
        /// </summary>
        public virtual List<Product> Products { get => _collection; set => SetProperty(ref _collection, value); }
    }
}
