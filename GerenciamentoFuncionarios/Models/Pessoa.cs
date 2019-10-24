using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoFuncionarios.Models
{
    public class Pessoa
    {
        [Key]
     public   int Id { get; set; }

     public  String Nome { get; set; }

     public   DateTime DataNascimento { get; set; }

    }

   
}
