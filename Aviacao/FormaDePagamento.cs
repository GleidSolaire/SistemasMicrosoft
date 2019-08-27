using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviacao
{
    [Table("FormasDePagamento")]
    public class FormaDePagamento
    {
        public int Id { get; set; }

        public String Forma { get; set; }

        public Decimal Valor {get;set;}

        public DateTime DataPagamento { get; set; }

        public Passagem Passagem { get; set; }
    }
}
