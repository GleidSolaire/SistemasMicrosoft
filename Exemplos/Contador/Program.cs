
*************************using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contador
{
    class Program
    {
        static void Main(string[] args)
        {

            string valor1 = Console.ReadLine();
            string valor2 = Console.ReadLine();

            Console.Write("Digite um valor: ");
            int a = int.Parse(valor1);
            Console.Write("Digite outro valor: ");
            int b = int.Parse(valor2);

           
            






        
         
        }

        static int somar(int a, int b)
        {
            int res = a + b;


            if (res < 10)
            {
                Console.Write("Pequeno");

            } else if (res >= 10 && res < 100)
            {
                Console.Write("Medio");
            }
            else if (res >= 100 )
            {
                Console.Write("Grande");
            }


            switch (res)
            {
                case 0:
                    Console.Write("ruim");
                    break;
                case 10:
                 
                    Console.Write("otimo");
                    break;
                default:
                    Console.Write("inexistente");
                    break;
            }
          

            return res;



            Console.ReadKey();
        }
    }
}
