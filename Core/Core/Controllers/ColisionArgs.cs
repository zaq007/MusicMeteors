using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Objects;

namespace Core.Controllers
{
    public class ColisionArgs : EventArgs
    {
        public GameObject fhhgf{get;set;}

        public ColisionArgs(GameObject a)
        { 
            fhhgf = a;
        }

    }
}
