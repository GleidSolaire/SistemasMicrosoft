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
            Pessoa p = new Pessoa() {
                nome = "Gleidson",
                nascimento = new DateTime(2000,01,31)

            
            };


        
            var res = from Pessoa in context.Pessoas
                      where Pessoa.nome == p.nome
                      select p;


            res.Cidade = curitiba;

            if (res == null)
            {

                context.Pessoas.Add(p);

            }

            Cidade curitiba = null;

            curitiba = (from c in context.cidades
                        where c.Nome == "Curitiba"
                        select c).FirstOrDefault();



           
            if (curitiba == null  )
            {
                curitiba = new Cidade() { Nome = "Curitiba" };
            }

           
            


            context.SaveChanges();
        }
    }
}
