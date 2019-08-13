using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Pessoa
    {
        public String  Nome { get; set; }
        public virtual void Falar ()
        {
            Console.WriteLine("Uma pessoa que fala");
        }
        public virtual void Falar(String Mensagem)
        {
            Console.WriteLine("Uma pessoa que fala: " +Mensagem);
        }

        public override string ToString()
        {
            return Nome;
        }
    }

}
