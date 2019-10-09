using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    public class TabuleiroJogo : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int[][] _Tabuleiro;

        public IReadOnlyList<int[]> Tabuleiro => Array.AsReadOnly(_Tabuleiro);
        public int JogadorAtual { get; private set; }
        public int NumeroJogadas { get; private set; } = 0;


        /// <summary>
        /// Calcula qual será o próximo jogador. 
        /// </summary>
        private void MudaJogadorAtual()
        {
            // 1 | 2 = 1 + 1 = 2 -- Era um   Vira Dois
            // 2 | 2 = 0 + 1 = 1 -- Era Dois Vira Um
            JogadorAtual = (JogadorAtual % NUMERO_JOGADORES) + 1;
        }
        private static int TAMANHO_TABULEIRO = 3;

        private static int NUMERO_JOGADORES = 2;

        /// <summary>
        /// Construtor com um jogo criado. Útil para execução de testes e simulações.
        /// </summary>
        /// <param name="Tabuleiro"></param>
        public TabuleiroJogo(int[][] Tabuleiro)
            : base()
        {
            this._Tabuleiro = Tabuleiro;
        }


        /// <summary>
        /// Construtor. Cria o tabuleiro com todas as posições vazias.
        /// </summary>
        public TabuleiroJogo()
        {
            //Inicializa o Tabuleiro.
            this._Tabuleiro = new int[TAMANHO_TABULEIRO][];
            for(int index = 0; index< TAMANHO_TABULEIRO; index++)
            {
                this._Tabuleiro[index] = new int[TAMANHO_TABULEIRO];
                for(int v = 0; v< TAMANHO_TABULEIRO; v++)
                {
                    this._Tabuleiro[index][v] =0;
                }
            }

            //new Random().Next(1) == Sorteia um número inteiro aleatório entre 0 e 1
            //Após somamos 1. Logo o número possível será 1 ou 2.
            this.JogadorAtual = (new Random().Next(1)) + 1;
        }

        /// <summary>
        /// Verifica qual o turno e a possibilidade da jogada.
        /// Caso não encontre nenhum óbice executará a jogada.
        /// </summary>
        /// <param name="Jogador">O autor da jogada.</param>
        /// <param name="posX">A coluna da jogada.</param>
        /// <param name="posY">A linha da jogada.</param>
        public void Jogar(int Jogador, int posX, int posY)
        {
            if (JogadorAtual != Jogador)
            {
                throw new Exception("Não é a sua vez de Jogar.");
            }
            if (_Tabuleiro[posY][posX] != 0)
            {
                throw new Exception("Esta posição já está ocupada.");
            }
            if(VerificarGanhador()!= 0)
            {
                throw new Exception("O Jogo já terminou. Reinicie para jogar.");
            }
            _Tabuleiro[posY][posX] = JogadorAtual;
            this.MudaJogadorAtual();
            this.NumeroJogadas++;
            this.NotifyPropertyChanged("Tabuleiro");
        }

        /// <summary>
        /// Retornar se existe algum ganhador.
        /// </summary>
        /// <returns>Retorna 0 se o jogo não acabou. -1 Se o jogo terminou empatado
        /// ou um número positivo para o jogador vencedor.</returns>
        public int VerificarGanhador()
        {
            if (NumeroJogadas == Math.Pow(TAMANHO_TABULEIRO, 2)){
                return -1;
            }
            /// Procurar uma linha igual na horizontal.
            /// 0 0 0
            /// 1 1 1
            /// 0 0 0
            for(int v=0; v<TAMANHO_TABULEIRO; v++)
            {
                int jogadaAnterior = _Tabuleiro[v][0];
                if (jogadaAnterior == 0)
                    continue;
                int h = 1;
                for (; h < TAMANHO_TABULEIRO; h++)
                {
                    if (jogadaAnterior != _Tabuleiro[v][h])
                        break;                    
                }
                if (h == TAMANHO_TABULEIRO)
                {
                    return jogadaAnterior;
                }
            }

            /// Procurar uma linha igual na vertical.
            /// 0 0 1
            /// 0 0 1
            /// 0 0 1
            for (int h = 0; h < TAMANHO_TABULEIRO; h++)
            {
                int jogadaAnterior = _Tabuleiro[0][h];
                if (jogadaAnterior == 0)
                    continue;
                int v = 1;
                for (; v < TAMANHO_TABULEIRO; v++)
                {
                    if (jogadaAnterior != _Tabuleiro[v][h])
                        break;
                }
                if (v == TAMANHO_TABULEIRO)
                {
                    return jogadaAnterior;
                }
            }


            /// Procurar por um vitorioso na diagonal
            /// 1 0 0
            /// 0 1 0
            /// 0 0 1

            int diagonal1 = _Tabuleiro[0][0];
            int diagonal2 = _Tabuleiro[0][TAMANHO_TABULEIRO - 1];
            int hDiagonal = 0;
            for (; hDiagonal < TAMANHO_TABULEIRO; hDiagonal++)
            {
                if( diagonal1 == 0 || 
                    diagonal1 != _Tabuleiro[hDiagonal][hDiagonal])
                {
                    diagonal1 = 0;
                }
                if (diagonal2 == 0 || 
                    diagonal2 != _Tabuleiro[hDiagonal][TAMANHO_TABULEIRO -1 -hDiagonal])
                {
                    diagonal2 = 0;
                }
            }
            //h somente será o Tamanho do Tabuleiro se o laço anterior ter executado todos os paços
            //ou seja encontrou uma diagonal que pertence somente a um usuário.
            if (hDiagonal == TAMANHO_TABULEIRO)
            {
                //Se diagonal1 for diferente de 0 retornar diagonal1 se não retornar diagonal 2;
                return diagonal1 != 0 ? diagonal1 : diagonal2;
            }


            return 0;
        }



    }
}
