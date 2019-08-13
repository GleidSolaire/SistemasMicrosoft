using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
  public  class Livro
    {
        public String titulo { get; set; }
        public List <Pessoa> autores { get; set; }
        public String genero { get; set; }
        public String editora { get; set; }
        public DateTime _dataEdicao { get; set; }

        public List<Emprestimo> Locacoes { get; set; }
    }
}
