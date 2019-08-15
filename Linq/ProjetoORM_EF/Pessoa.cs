using System;
using System.Collections.Generic;
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

        public Cidade cidade { get; set; }
        
    }
}
