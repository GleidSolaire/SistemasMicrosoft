using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao.Models
{
    public class Torneio
    {
        public int Id { get; set; }
        public string NomeTorneio { get; set; }
        public int QuantidadeJogadores { get; set; }
        public DateTime Inicio { get; set; }

        public String Dono { get; set; }

    }
}
