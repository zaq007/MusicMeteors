using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Misc
{
    public static class Return
    {
        public static String Message { get; set; }

        static Return()
        {
            Message = "OK";
        }
    }
}
