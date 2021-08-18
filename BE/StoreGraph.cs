using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class StoreGraph : BasicGraph
    {
        private List<Store> _collection;
        /// <summary>
        /// The items to show graph for
        /// </summary>
        public virtual List<Store> Stores

        { 
            get => _collection; set => SetProperty(ref _collection, value); 
        }
    }
}
