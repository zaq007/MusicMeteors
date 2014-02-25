using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Menu
{
    static public class Return
    {
        static public string Message { get; set; }

        static Return()
        {
            Message = "OK";
        }
    }
}
