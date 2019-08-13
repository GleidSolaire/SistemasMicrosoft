using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa p1 = new Pessoa();

            p1.nome = "Gleidson Almeida";

            Livro meulivro = new Livro();


            meulivro.autores = new List<Pessoa>();
            meulivro.autores.Add(p1);

            meulivro.genero = "Fantassia";
            meulivro.titulo = "A historia da minnha vida";
            meulivro._dataEdicao = new DateTime(2019, 7, 8);
            meulivro.editora = "Cosmo Editoria ltda";

            Console.ReadKey();
        }
    }
}
