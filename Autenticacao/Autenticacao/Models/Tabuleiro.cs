using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao.Models
{
    public class Tabuleiro
    {
        private static int NUMERO_COLUNAS = 7;
        private static int NUMERO_LINHAS = 6;
        public int [,] RepresentacaoTabuleiro { get; set; }

        //public int VerificarVencedorColuna ()
        //{
        //    int contador = 1;
        //    for (int linha = 1; linha < RepresentacaoTabuleiro.GetLength(1); coluna++)
        //    {
        //        if (RepresentacaoTabuleiro[coluna])
        //    }
        //}

        public Boolean isSemPosicoes ()
        {
            for (int i = 0; i < RepresentacaoTabuleiro.GetLength(0); i++)
            {
                if (RepresentacaoTabuleiro[i, RepresentacaoTabuleiro.GetLength(1)-1]==0)
                {
                    return false;                }
            }
            return true;
        }
        public void Jogar (int Jogador, int Posicao) 
           
        {
            if (Posicao < 0 )
            {
                throw new ArgumentException("A posicçao não póde ser menor que zero");

            }else if (Posicao > NUMERO_COLUNAS - 1)
            {
                throw new ArgumentException($"A posição não pode ser maior que {NUMERO_COLUNAS}");
            }

            int linha = 0;
            do
            {
                if (RepresentacaoTabuleiro[Posicao, linha] == 0)
                {
                    RepresentacaoTabuleiro[Posicao, linha] = Jogador;
                    return;

                }
            }
            while (++linha < RepresentacaoTabuleiro.GetLength(1));
        }

       
    }
}
