using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Patterns
{
    public interface IPoolable
    {
        bool Free { get; set; }
    }
}
