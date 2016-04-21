using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;


namespace FirstApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=0, b=0;
            String readConf = System.Configuration.ConfigurationManager.AppSettings["read"];
            if (readConf.Equals("console"))
            {
                Console.WriteLine("Input a");
                bool aIsNumber = Int32.TryParse(Console.ReadLine(), out a);
                Console.WriteLine("Input b");
                bool bIsNumber = Int32.TryParse(Console.ReadLine(), out b);
                if (!aIsNumber || !bIsNumber)
                {
                    Console.WriteLine("Incorrect input");
                    Console.ReadLine();
                    return;
                }
            }
            else if (readConf.Equals("resourceFile"))
            {                
                a=Int32.Parse(Resource1.a);
                b=Int32.Parse(Resource1.b);
            }

            String placeConf = System.Configuration.ConfigurationManager.AppSettings["choice"];
            if (placeConf.Equals("library"))
            {
                Calculator cal = new Calculator();
                Console.WriteLine("a+b=" + cal.plus(a, b));
                Console.WriteLine("a-b=" + cal.minus(a, b));
                Console.WriteLine("a*b=" + cal.multiply(a, b));
                Console.WriteLine("a/b=" + cal.divide(a, b));
            }
            else if (placeConf.Equals("method"))
            {
                Console.WriteLine(a + b);
            }
            Console.ReadLine();
        }
    }
}
