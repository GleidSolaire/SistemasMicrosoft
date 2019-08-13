using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  public  class Homem: Pessoa
    {
        public override void Falar()
        {
            Console.WriteLine("Um homem que fala");

        }
        public void Modotroglodita ()
        {
            Console.WriteLine("E@#%R");
        }
    }
}
