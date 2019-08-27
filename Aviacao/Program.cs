using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviacao
{
    class Program
    {
        static void Main(string[] args)
        {

            Pessoa pessoa = new Pessoa()
            {
                Nome = "Alex Pinheiro das Graças"
            };
            Cidade CWB = new Cidade() { Nome = "Curitiba" };
            Cidade BSB = new Cidade() { Nome = "Brasilia" };
            Cidade VIX = new Cidade() { Nome = "Vitória" };
            Voo vooCWBBSB = new Voo();
            vooCWBBSB.Origem = CWB;
            vooCWBBSB.Destino = BSB;
            Voo vooBSBVIX = new Voo();
            vooBSBVIX.Origem = BSB;
            vooBSBVIX.Destino = VIX;
            Passagem passagem = new Passagem();
            passagem.Passageiro = pessoa;
            passagem.Trechos = new List<Voo>();
            passagem.Trechos.Add(vooCWBBSB);
            passagem.Trechos.Add(vooBSBVIX);
            ModelAviacao context = new ModelAviacao();
            context.Pessoas.Add(pessoa);
            context.SaveChanges();
        }
    }
}
