using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace task3
{
    public class Matrix
    {
        public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
        {
            try
            {


                if (matrix1.GetLength(1)<1|| matrix2.GetLength(1) < 1 ||matrix1.GetLength(1)!=matrix2.GetLength(0))
                {
                    throw new ArithmeticException("Matrices cannot be multuplyed");
                }
                else
                {
                    double[,] multyMatrix = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
                    for(int i = 0; i < matrix1.GetLength(0); i++)
                    {
                        for(int j = 0; j < matrix2.GetLength(1); j++)
                        {
                            double summ = 0;
                            for(int k = 0; k < matrix1.GetLength(1);k++)
                            {
                                summ += matrix1[i, k] * matrix2[k, j];
                            }
                            multyMatrix[i, j] = summ;
                        }
                    }
                    return multyMatrix;
                }
            }
            catch(FormatException e)
            {
                throw new FormatException("Incorrect matrix");
            }
        }

        public static double[,] ReadMatrixFromFile(string path)
        {
            double[,] matrix = null;
            string[] buf = File.ReadAllLines(path);
            if (buf.Length != 0)
            {
                matrix = new double[buf.Length, buf[0].Split(' ').Length];
                try
                {
                    int i = 0;
                    foreach (string line in buf)
                    {
                        double[] row = line.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n => double.Parse(n)).ToArray();
                        int j = 0;
                        foreach(double n in row)
                        {
                            matrix[i, j] = n;
                            j++;
                        }
                        i++;
                    }
                }
                catch(FormatException e)
                {
                    throw new FormatException("Incorrect matrix: format of the number is not correct");
                }
                catch(IndexOutOfRangeException e)
                {
                    throw new IndexOutOfRangeException("Incorrect matrix");
                }
            }
            else
            {
                return new double[0,0];
            }
            
            return matrix;
        }
    }
}
