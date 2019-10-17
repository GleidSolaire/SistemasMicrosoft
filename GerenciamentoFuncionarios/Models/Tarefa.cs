using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoFuncionarios.Models
{
    public class Tarefa
    {
        public int Id {get;set;}
        [Required]
        public DateTime Inicio { get; set; }

        public DateTime? Fim { get; set; }

        [Required]
        public String Titulo { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }

        public Funcionario Executor { get; set; }
        
        public Departamento Departamentos { get; set; }

        [ForeignKey("Executor")]
        public int? ExecutorId { get; set; }
    }
}
