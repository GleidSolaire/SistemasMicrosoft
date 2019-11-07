using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao.Models
{
    public class Torneio
    {
        public IList<Jogador> Jogadores { get; set; }

        public IList<Jogo> Jogos { get; set; }
        public int Id { get; set; }
        [Display (Name ="Nome do Torneio")]
        public string NomeTorneio { get; set; }
        [Display(Name = "Quantidade de Jogadores")]
        public int QuantidadeJogadores { get; set; }
        [Display(Name = "Inicio do Torneio")]
        [Range (2,32, ErrorMessage = "Quantidade deve ser entre 2 e 32 jogadores")]
        [DataType(DataType.Date)]
        public DateTime Inicio { get; set; }
        [Required]
        public String Dono { get; set; }

        public Decimal Premiacao { get; set; }
    }
}
