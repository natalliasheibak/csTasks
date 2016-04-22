using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before starting creating exemplars of the class: count = " + ClassWithCount.ExemplarCount);
            ClassWithCount class1 = new ClassWithCount();
            ClassWithCount class2 = new ClassWithCount();
            Console.WriteLine("After creating 2 exemplars of the class: count = " + ClassWithCount.ExemplarCount);
            ClassWithCount class3 = new ClassWithCount();
            ClassWithCount class4 = new ClassWithCount();
            Console.WriteLine("After creating 4 exemplars of the class: count = " + ClassWithCount.ExemplarCount);
            Console.ReadLine();
        }
    }
}
