using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Patterns
{
    public class Pool<T> : List<T> where T : IPoolable 
    {
        public Pool()
            : base()
        { }

        public T TryGet(Type t)
        {
            for(int i = 0; i < this.Count; i++)
                if(this[i].Free == true && this[i].GetType() == t)
                    return this[i];
            return default(T);
        }
    }
}
