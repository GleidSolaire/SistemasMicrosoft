using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     public class Mulher: Pessoa
    {
        public override void Falar()
        {
            var oldColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Red;


            base.Falar();
            Console.BackgroundColor = oldColor;

        }

        public void ModoFofoqueira()
        {
            Console.WriteLine("Blablablablalbla");
        }
    }

}
