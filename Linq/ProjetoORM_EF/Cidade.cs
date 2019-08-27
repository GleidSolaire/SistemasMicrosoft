using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoORM_EF
{
   public class Cidade
    {
        public int id { get; set; } 


        [Required]
        [Column("Nome_cidade")]

        [MaxLength(50, ErrorMessage = "Cidade deve ter no maximo 50 caracteres")]
        public String Nome { get; set; }

        [InverseProperty("Cidade")]

        public IList<Pessoa> Moradores { get; set; }

        [InverseProperty("LocaldeNascimento")]

        public IList<Pessoa> PessoasNaturais { get; set; }

    }
}
