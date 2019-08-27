using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviacao
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public String Nome { get; set; }
        public IList<Passagem> Passagens { get; set; }
    }
}
