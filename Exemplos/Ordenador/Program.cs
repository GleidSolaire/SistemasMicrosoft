using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenador
{
    class Program
    {
        static void Main(string[] args)
        {

            int tamanho = 100;
            Random r = new Random();
            int[] valores = new int[tamanho];
            while (tamanho > 0)
            {
                valores[--tamanho] = r.Next(1000);
            }

            //ordernar
            Console.WriteLine("valores: ");
            foreach(int i in valores)
            {

                Console.WriteLine(i + ",");
                Console.ReadKey();

            }
        }
        
    } 
}
