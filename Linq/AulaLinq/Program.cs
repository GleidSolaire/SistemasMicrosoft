using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaLinq
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = new int[7] {4,5,6,7,8,9,11};

            var pares = from num in numbers
                        where (num % 2) == 0
                        select num;

            Console.WriteLine("Numeros divisiveis por 2:");

            var portres = from num in numbers
                        where (num % 3) == 0
                        select num;
            



            foreach (int num in pares) {

                Console.WriteLine(num + "");

            }

            Console.WriteLine("Numeros divisiveis por 3: ");

            foreach (int num3 in portres)
            {

                Console.WriteLine(num3 + "");

            }

            ExemploPessoa();

            Console.ReadKey();
            
        }

        static void ExemploPessoa()
        {
            Cidade vitoria = new Cidade (){ nome = "Vitoria" };
            Cidade curitiba = new Cidade () { nome = "Curitiba" };

            List<Pessoa> pessoas = new List<Pessoa>();

            pessoas.Add(new Pessoa()
            {

                nome = "Gleidson",

                datanasciemento = new DateTime(2000, 12, 31),

                Cidade = curitiba
                

            });

            pessoas.Add(new Pessoa()
            {

                nome = "Teresa",

                datanasciemento = new DateTime(2000, 12, 11),


                Cidade = curitiba
            });



            pessoas.Add(new Pessoa()
            {

                nome = "Alccione",

                datanasciemento = new DateTime(1989, 12, 11),


                Cidade = vitoria
            });

            var resultado = from p in pessoas
                            where p.datanasciemento.Month == 12   
                            orderby p.datanasciemento ascending
                            select p.nome + " idade "+(DateTime.Now.Year - p.datanasciemento.Year).ToString();

            foreach (var x in resultado)
            {
                Console.Write(x + " , ");
            }

            Console.WriteLine("");

            var reultadoGroup = from p in pessoas
                                group p by p.Cidade;

            foreach(var grupo in reultadoGroup)
            {
                Console.WriteLine("Inicio grupo: "+grupo.Key.nome);

                foreach( var item in grupo )
                {
                    Console.Write(item.nome+ ",");
                }
            }


        }
    }
}
