using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using task3;

namespace task4console
{
    class Program
    {
        static void Main(string[] args)
        {
            string matrix1Path = ConfigurationManager.AppSettings["Matrix1"];
            string matrix2Path = ConfigurationManager.AppSettings["Matrix2"];
            try
            {
                double[,] matrix1 = Matrix.ReadMatrixFromFile(matrix1Path);
                double[,] matrix2 = Matrix.ReadMatrixFromFile(matrix2Path);
            
                double[,] multiMatrix = Matrix.Multiply(matrix1, matrix2);

                for (int i = 0; i < multiMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < multiMatrix.GetLength(1); j++)
                    {
                        Console.Write(String.Format("{0:0.##} ",multiMatrix[i, j]));
                    }
                    Console.WriteLine();
                }
            }
            catch(ArithmeticException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
