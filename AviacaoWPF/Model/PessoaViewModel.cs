using Aviacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviacaoWPF.Model
{
   public class PessoaViewModel
    {
        public IList<pessoa> Pessoas { get; set; }

        private ModelAviacao context { get; set; }

        public pessoa pessoaSelecionada { get; set; }
        public PessoaViewModel()
        {
            context = new ModelAviacao();

            this.Pessoas = context.Pessoas.ToList();
            this.pessoaSelecionada = context.Pessoas.FirstOrDefault();

        }
    }
}
