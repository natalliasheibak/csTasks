using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            string doubleNumber=String.Empty;
            string intNumber=String.Empty;
            int doubleCount=0;
            double doubleSumm=0;
            int intCount=0;
            int intSumm = 0;
            string text=String.Empty;

            Console.WriteLine("Start inputting values. Type \"Stop\" to finish");
            while (!(line = Console.ReadLine()).Equals("Stop"))
            {
                int i;
                double d;
                //Обработка целочисленного значения
                if(Int32.TryParse(line, out i))
                {
                    intCount++;
                    intSumm += i;
                    intNumber += String.Format("{0,10}\n", i);
                }
                //Обработка значения с плавающей точкой
                else if (Double.TryParse(line, out d))
                {
                    doubleCount++;
                    doubleSumm += d;
                    doubleNumber += String.Format("{0,10:0.##}\n", d);
                }
                //Обработка значений, не являющиеся числами
                else
                {
                    text = text + ";" + line;
                }
            }
            //Вывод чисел и их среднее арифметическое
            intNumber += String.Format("Average={0}", (intSumm / intCount));
            Console.WriteLine(intNumber);
            doubleNumber += String.Format("Average={0:0.##}", (doubleSumm / doubleCount));
            Console.WriteLine(doubleNumber);

            string buf;
            string[] lines = text.Split(';');
            //Сортировка значений не-чисел
            if (lines.Length > 0)
            {
                for (int i = 1; i < lines.Length-1; i++)
                {
                    for (int j = 0; j < (lines.Length - i); j++)
                    {
                        if (lines[j].Length > lines[j + 1].Length)
                        {
                            buf = lines[j];
                            lines[j] = lines[j + 1];
                            lines[j + 1] = buf;
                        }

                        else if (lines[j].Length > lines[j + 1].Length)
                        {
                            if (String.Compare(lines[j], lines[j + 1]) > 0)
                            {
                                buf = lines[j];
                                lines[j] = lines[j + 1];
                                lines[j + 1] = buf;
                            }
                        }
                    }
                }
                //Вывод значений, не являющихся числами
                foreach (string l in lines)
                {
                    Console.WriteLine(l);
                }
                Console.ReadLine();
            }
        }
    }
}
