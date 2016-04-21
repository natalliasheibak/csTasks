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
            Console.WriteLine("Type the name of directory you want to create");
            string dirPath = @"C:\Users\Natallia_Sheibak@epam.com\Documents\"+Console.ReadLine();
            Console.WriteLine("Input the name of text file you want to create in the directory");
            string outputFile = dirPath + @"\"+Console.ReadLine()+".txt";
            Console.WriteLine("Input the PATH of file you want take the text from");
            string inputFile = Console.ReadLine();

            Directory.CreateDirectory(dirPath);
            var output=File.Create(outputFile);
            output.Close();
            int lineCount = 0;      //Подсчет строк

            //  Чтение и запись текста в файл
            foreach(string line in File.ReadLines(inputFile))
            {
                File.AppendAllText(outputFile, line);
                lineCount++;
                //Прервать запись, если количество строк превышает 20
                if (lineCount >= 20)
                {
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
