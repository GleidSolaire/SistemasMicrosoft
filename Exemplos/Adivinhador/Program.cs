using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adivinhador
{
    class Program
    {
        static void Main(string[] args)
        {

            Random sorteador = new Random();
            int valor = sorteador.Next(100);



            int numdigitado = 0;
            do
            {
                Console.Write("Advinhe  um numero de 0 a 100: ");
                numdigitado = int.Parse(Console.ReadLine());


                if (numdigitado > valor)
                {
                    Console.WriteLine("Valor muito alto");
                }

                if (numdigitado < valor)
                {
                    Console.WriteLine("Valor muito baixo");
                }
                else if (numdigitado == valor)
                {

                    Console.WriteLine("ACERTOU MISERAVI");
                }
            } while (valor != numdigitado);

            Console.ReadKey();
        }
    }
}
