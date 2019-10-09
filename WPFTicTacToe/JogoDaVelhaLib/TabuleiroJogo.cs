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
        /// <summary>
        /// Tamanho do tabuleiro de jogo da velha usualmente 3x3.
        /// </summary>
        private static int TAMANHO_TABULEIRO = 3;

        /// <summary>
        /// Número de jogadores do jogo da velha usualmente 2.
        /// </summary>
        private static int NUMERO_JOGADORES = 2;

        /// <summary>
        /// Evento utilizado para lançar eventos caso ocorra alguma mudança. 
        /// Bastante Útil para frameworks como o WPF que devem se atualizar
        /// caso ocorra alguma mudança no Model.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int[][] _Tabuleiro;

        /// <summary>
        /// Entrega um Array multimensional somente leitura com o Tabuleiro..
        /// </summary>
        public IReadOnlyList<int[]> Tabuleiro => Array.AsReadOnly(_Tabuleiro);

        /// <summary>
        /// O jogador atual. 
        /// </summary>
        public int JogadorAtual { get; private set; }

        /// <summary>
        /// A quantidade de jogadas executadas até o momento.
        /// </summary>
        public int NumeroJogadas { get; private set; } = 0;

        public int Ganhador { get => VerificarGanhador(); }

        /// <summary>
        /// Calcula qual será o próximo jogador. 
        /// </summary>
        private void MudaJogadorAtual()
        {
            // 1 | 2 = 1 + 1 = 2 -- Era um   Vira Dois
            // 2 | 2 = 0 + 1 = 1 -- Era Dois Vira Um
            JogadorAtual = (JogadorAtual % NUMERO_JOGADORES) + 1;
        }


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
            // O jogador atual deve ser o jogador realizando a jogada.
            if (JogadorAtual != Jogador)
            {
                throw new Exception("Não é a sua vez de Jogar.");
            }
            //A posição não poderá estar ocupada.
            if (_Tabuleiro[posY][posX] != 0)
            {
                throw new Exception("Esta posição já está ocupada.");
            }
            //Caso já exista um vencedor (1 ou 2).
            //Ou o jogo tenha terminado empatada(-1).
            //Não é possível mais realizar jogadas.
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
        private int VerificarGanhador()
        {
            if (NumeroJogadas == Math.Pow(TAMANHO_TABULEIRO, 2)){
                return -1;
            }
            /// Procurar uma linha igual na horizontal.
            /// 0 0 0    1 1 1    0 0 0 
            /// 1 1 1 ou 0 0 0 ou 0 0 0
            /// 0 0 0    0 0 0    1 1 1
            // v = a linha a ser verificada.
            for (int v=0; v<TAMANHO_TABULEIRO; v++)
            {
                //Se a coluna começa com 0, não precisa ser verificada.
                int jogadaAnterior = _Tabuleiro[v][0];
                if (jogadaAnterior == 0)
                    continue;
                int h = 1;
                for (; h < TAMANHO_TABULEIRO; h++)
                {
                    //se existe um número diferente na coluna anterior também não precisa
                    //ser mais verificado, pois para haver um vencedor 
                    //precisa que toda a linha seja igual.
                    if (jogadaAnterior != _Tabuleiro[v][h])
                        break;                    
                }
                if (h == TAMANHO_TABULEIRO)
                {
                    //Se h==tamanho do tabuleiro o laço de repetição encontrou valores
                    //iguais para toda uma verificação.
                    //Logo retorne o valor encontrado.
                    return jogadaAnterior;
                }
            }

            /// Procurar uma linha igual na vertical.
            /// 0 0 1    1 0 0    0 1 0
            /// 0 0 1 ou 1 0 0 ou 0 1 0
            /// 0 0 1    1 0 0    0 1 0
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
            /// 1 0 0    0 0 1
            /// 0 1 0 ou 0 1 0
            /// 0 0 1    1 0 0

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
