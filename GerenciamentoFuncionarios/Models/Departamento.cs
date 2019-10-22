using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoFuncionarios.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public String Nome { get; set; }

    
        [Required]
        public virtual Funcionario Responsavel
        {
            get;set;
        }
        [InverseProperty("Lotacao")]
        public virtual IList<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

        [ForeignKey("Responsavel")]
        [Display(Name = "Responsável")]
        public int ResponsavelId
        { get;set;}
    }
}
