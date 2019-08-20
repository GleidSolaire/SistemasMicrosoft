using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoORM_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelPessoas context = new ModelPessoas();
            Pessoa p = new Pessoa()
            {
                nome = "Gleidson",
                nascimento = new DateTime(2019, 12, 15)
            };



            Pessoa p2 = new Pessoa()
            {
                nome = "Emanoelle",
                nascimento = new DateTime(2001, 08, 09)
            };
            Pessoa resultado = PersistirPessoa(context, p);
            Pessoa resultadop2 = PersistirPessoa(context, p2);

            Cidade curitiba = null;
            curitiba = (from c in context.cidades
                        where c.Nome == "Curitiba"
                        select c).FirstOrDefault();
            if (curitiba == null)
            {
                curitiba = new Cidade() { Nome = "Curitiba" };
            }

            resultado.cidade = curitiba;
            resultadop2.cidade = curitiba;

            foreach (Pessoa pessoa in curitiba.Moradores)
            {
                Console.WriteLine("Nome: " + pessoa.nome);
            }

            Casa casa1 = new Casa()
            {
                cidade = curitiba,
                endereco = "rua xxx, N 1111, Bairro: yyyy"
            };

            casa1.Moradores.Add(resultado);
            casa1.Moradores.Add(resultadop2);

            context.casas.Add(casa1);


            context.SaveChanges();


            Console.ReadKey();

          
        }

        private static Pessoa PersistirPessoa(ModelPessoas context, Pessoa p)
        {
            var resultado = (from pessoa in context.Pessoas
                             where pessoa.nome == p.nome
                             select pessoa).FirstOrDefault();

            if (resultado == null)
            {
                resultado = context.Pessoas.Add(p);
            }

            return resultado;
        }
    }
}
