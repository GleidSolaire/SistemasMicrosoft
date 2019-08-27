using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoORM_EF
{
    public class Pessoa
    {
        public int Id { get; set; }
        public String nome { get; set; }
        public DateTime nascimento { get; set; }

        public String documento;

        public int telefone;

        public Cidade cidade { get; set; }

        public Cidade LocaldeNascimento {get;set;}

        [InverseProperty("Moradores")]
        public IList<Casa> Casas { get; set; }

        public int idade {
                        get{
          int idade = DateTime.Now.Year - this.nascimento.Year;
                if(DateTime.Now.Month >= this.nascimento.Month && DateTime.Now.Day >= this.nascimento) 
                 {
                    return idade;
                               
                      }                  
                   return idade-1;

                    }
           
            }
    }
}
