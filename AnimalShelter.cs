using System;
using System.Collections.Generic;
using System.Text;

namespace Praksa 
{
    class AnimalShelter<T> 
    {
        private T data;

        public T name
            {
          
       
        get
            {
                return this.data;
            }
        set
            {
                this.data = value;
            }
}
    }
}
