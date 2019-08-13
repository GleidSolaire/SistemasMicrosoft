using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCarro
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Corsa c = new Corsa();
                Corsa d = null;
                 


            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Erro de execução");
            }
            finally {
                Console.ReadKey();
            }
        }
    }
}
