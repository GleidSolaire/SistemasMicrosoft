using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeroFlutuantes
{
    class Program
    {
        static void Main(string[] args)
        {
            float a= 1.1f;
            double b= 1.1;
            decimal c= 1.1m;

            Console.WriteLine("float: " +a.ToString("e20"));

            Console.WriteLine("double: "+b.ToString("e20"));

            Console.WriteLine("decimal: "+c.ToString("e20"));

            Console.ReadKey();

        }
    }
}
