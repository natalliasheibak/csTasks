using System;
using System.Collections.Generic;
using System.Collections;
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
            Console.WriteLine("Input number of iteration");
            int count = int.Parse(Console.ReadLine());
            LogWriter log = new LogWriter();

            Console.WriteLine("Calculation of operations of collection List is in progress...");
            log.Write( "List:\r\n");
            List<int> list = new List<int>();
            CollectionTimer timer = new CollectionTimer(list,count);
            log.Write( timer.ToString());
            Console.WriteLine(timer.ToString());

            Console.WriteLine("Calculation of operations of collection LinkedList is in progress...");
            log.Write( "LinkedList:\r\n");
            LinkedList<int> linkedList = new LinkedList<int>();
            timer = new CollectionTimer(linkedList,count);
            log.Write( timer.ToString());
            Console.WriteLine(timer.ToString());

            Console.WriteLine("Calculation of operations of collection SortedSet is in progress...");
            log.Write( "SortedSet:\r\n");
            SortedSet<int> sortedSet = new SortedSet<int>();
            timer = new CollectionTimer(sortedSet,count);
            log.Write( timer.ToString());
            Console.WriteLine(timer.ToString());

            Console.WriteLine("Calculation of operations of collection Dictionary is in progress...");
            log.Write( "Dictionary:\r\n");
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            DictionaryTimer timer2 = new DictionaryTimer(dictionary,count);
            log.Write( timer2.ToString());
            Console.WriteLine(timer2.ToString());

            Console.WriteLine("Calculation of operations of collection SortedDictionary is in progress...");
            log.Write( "SortedDictionary:\r\n");
            SortedDictionary<int, int> sortedDictionary = new SortedDictionary<int, int>();
            timer2 = new DictionaryTimer(sortedDictionary,count);
            log.Write( timer2.ToString());
            Console.WriteLine(timer2.ToString());

            Console.WriteLine("Calculation of operations of collection Queue is in progress...");
            log.Write( "Queue:\r\n");
            Queue<int> queue = new Queue<int>();
            QueueTimer timer3 = new QueueTimer(queue,count);
            log.Write( timer3.ToString());
            Console.WriteLine(timer3.ToString());

            Console.WriteLine("Calculation of operations of collection Stack is in progress...");
            log.Write( "Stack:\r\n");
            Stack<int> stack = new Stack<int>();
            StackTimer timer4 = new StackTimer(stack,count);
            log.Write( timer4.ToString());
            Console.WriteLine(timer3.ToString());

            Console.ReadLine();
        }
    }
}
