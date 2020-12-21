using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Extension
    {
        public static void Print(this string text) 
        {
            Console.WriteLine(text);
        }
    }
}
