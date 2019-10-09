using JogoDaVelha;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JogoDaVelhaWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private TabuleiroJogo _tabuleiro = new TabuleiroJogo();

        public TabuleiroJogo Tabuleiro { get => _tabuleiro;  set
            {
                _tabuleiro = value;
                NotifyPropertyChanged();
            }
            }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void ProcedimentosFinalJogo(int estado)
        {
            switch (estado)
            {
                case 1:
                case 2:
                    MessageBox.Show($"O Jogador {estado} é o vencedor!");
                    break;
                case -1:
                    MessageBox.Show("Não houve vencedores.");
                    break;
            }
            if (MessageBox.Show("Começar outro Jogo?", "Jogo da Velha",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.ReiniciarJogo();
            }
        }

        private void ReiniciarJogo()
        {
            this.Tabuleiro = new TabuleiroJogo();
        }

        private void Jogar(int posX, int posY)
        {
            try
            {
                this.Tabuleiro.Jogar(this.Tabuleiro.JogadorAtual, posX, posY);
                var estado = this.Tabuleiro.Ganhador;
                if (estado != 0)
                {
                    ProcedimentosFinalJogo(estado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Jogo da Velha", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }
        }

        private void Posicao00_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            // Existem as linhas de desenho. Por isso dividir por dois.
            // 0/2 = 0, 2/2 = 1, 4/2 =2.
            row /= 2;
            // Existem as colunas de desenho. Por isso dividir por dois.
            // 0/2 = 0, 2/2 = 1, 4/2 =2.
            column /= 2;

            this.Jogar(row, column);
        }
    }
}
