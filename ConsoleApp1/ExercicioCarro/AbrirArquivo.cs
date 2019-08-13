using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCarro
{
    public class AbrirArquivo

    {

        private static String obeterCaminho ()
        {
            Console.WriteLine("Informe o caminho do arquivo");
            return Console.ReadLine();
        }

        public  static void LerArquivo ()
        {
            try
            {

                String path = obeterCaminho() ;


                var linhas = System.IO.File.ReadAllLines(path);
                foreach (string linha in linhas)
                {
                    Console.WriteLine(linha);
                    String novoTexto = Console.ReadLine();
                    System.IO.File.WriteAllText(path, novoTexto);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void EditarArquivo()
        {
            String path = @"C:\Users\1828282\Documents\Arquivo.txt";
            var file = System.IO.File.Open(path, System.IO.FileMode.Open);
        }
    }
}
