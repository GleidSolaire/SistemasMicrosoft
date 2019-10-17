using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoFuncionarios.Models
{
    public class Funcionario: Pessoa
    {
        public Departamento Lotaocao { get; set; }
    }
}
