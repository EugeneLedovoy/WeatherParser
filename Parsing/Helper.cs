using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public static class Helper
    {
        public static string MinusHelper(this string temp)
        {
            string tempNew;
            if (temp.Contains("−"))
                return tempNew = temp.Replace("−", "-");
            else
                return tempNew = temp;
        }

    }
}
