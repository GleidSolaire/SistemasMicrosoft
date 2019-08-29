using Aviacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AviacaoWPF
{
    /// <summary>
    /// Lógica interna para WindowPessoa.xaml
    /// </summary>
    public partial class WindowPessoa : Window
    {
     public   Model.PessoaViewModel PessoaViewModel { get; set; }
        public WindowPessoa()
        { 
            InitializeComponent();
            this.PessoaViewModel = new Model.PessoaViewModel();
            this.DataContext = this;
        }
    }
}
