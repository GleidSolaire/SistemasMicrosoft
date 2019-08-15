using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoORM_EF
{
   public class Cidade
    {
        public int id { get; set; } 

        [Column("Nome_cidade")]

        public String Nome { get; set; }
    }
}
