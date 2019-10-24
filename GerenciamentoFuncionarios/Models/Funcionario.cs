using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoFuncionarios.Models
{
    public class Funcionario: Pessoa
    {
        [InverseProperty("Funcionarios")]
        public virtual Departamento Lotacao { get; set; }

       
        [ForeignKey("Lotacao")]
        [Display(Name = "Lotação")]
        public int? LotacaoId
        { get; set; }
       
    }
}
