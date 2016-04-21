using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a path to the file you want to read");
            string path=Console.ReadLine();
            string text = File.ReadAllText(path);
            text = text.ToLower();
            text = String.Format("{0: dd.MM.yyyy HH:mm:ss.fff} ", DateTime.Now)+text.Replace(".", String.Format(".\n{0: dd.MM.yyyy HH:mm:ss.fff}", DateTime.Now));
            Console.WriteLine(text);
            Console.ReadLine();
        }
    }
}
