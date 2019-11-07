using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao.Models
{
    public interface JogadorComputador
    {
        int CalcularJogada(Tabuleiro tabuleiro);
    }
}
