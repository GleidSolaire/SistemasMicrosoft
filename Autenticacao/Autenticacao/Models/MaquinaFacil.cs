using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao.Models
{
    public class MaquinaFacil : JogadorComputador
    {
       

        public int CalcularJogada(Tabuleiro tabuleiro)
        {
            int jogada = new Random().Next(Tabuleiro.NUMERO_COLUNAS);

            return jogada;
        }
    }
}
