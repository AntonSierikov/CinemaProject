using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.Abstract
{
    public class EntityFilter<T> 
    {
        public T FilterValue { get; set; }

        public bool IsAvailable { get; set; }
    }
}
