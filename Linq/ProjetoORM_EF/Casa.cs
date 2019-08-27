using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoORM_EF
{
    [Table("Casa")]
 public   class Casa
    {

        [Key]
        public int id { get; set; }
        [InverseProperty("Casas")]
        public IList<Pessoa> Moradores { get; set; } = new List<Pessoa>();

        public Cidade cidade { get; set; }

        public String endereco { get; set; }

    }
}
