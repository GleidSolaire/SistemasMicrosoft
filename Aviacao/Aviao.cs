using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviacao
{
    [Table("Avioes")]
    public class Aviao
    {
        public int Id { get; set; }

        public IList<Voo> Voos { get; set; }
    }
}
 