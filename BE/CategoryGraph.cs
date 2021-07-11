using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class CategoryGraph:BasicGraph
    {
        private ICollection<Category> _collection;
        /// <summary>
        /// The items to show graph for.
        /// </summary>
        public virtual ICollection<Category> Categories 
        {
            get => _collection; set => SetProperty(ref _collection, value); 
        }
    }
}
