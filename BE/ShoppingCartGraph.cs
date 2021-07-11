using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class ShoppingCartGraph :BasicGraph
    {
        private ICollection<ShoppingCart> _collection;
        /// <summary>
        /// The items to show graph for.
        /// </summary>
        public virtual ICollection<ShoppingCart> ShoppingCarts
        {
            get => _collection; set => SetProperty(ref _collection, value);
        }

    }
}
