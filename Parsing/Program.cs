﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new ProcessData();
            p.GetPreDataAsync();
            Console.ReadLine();
        }
    }
}
