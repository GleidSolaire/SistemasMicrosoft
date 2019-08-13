using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Pessoa p = new Pessoa();

            Homem h = new Homem();

            Mulher m = new Mulher();

            p.Falar();
            h.Falar();

            m.Falar();

            Pessoa p2 = new Homem();
            Pessoa p3 = new Mulher();

            p2.Falar();
            p3.Falar();

            Pessoa p4 = CriarPessoa();
            p4.Falar();
            p4.Nome = "Lucimar";

            Console.WriteLine("To syting():");
            Console.WriteLine(p4.ToString());
            Console.ReadKey();



        }
        private static Pessoa CriarPessoa()
        {
            Random r = new Random();
            if (r.Next(10) < 5)
            {
                return new Homem();
            }
            else
            {
                return new Mulher();

            }
        }
    }
}
