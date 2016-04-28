using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class StackTimer:ITimer
    {
        Stack<int> stack;
        int count;
        public StackTimer(Stack<int> stack, int count)
        {
            this.stack = stack;
            this.count = count;
        }

        public TimeSpan AddTimer()
        {
            DateTime startTime=DateTime.Now;
            for(int i = 0; i < count; i++)
            {
                stack.Push(i);
            }
            return (DateTime.Now.Subtract(startTime));
        }

        public TimeSpan ReadTimer()
        {
            DateTime startTime=DateTime.Now;
            for(int i = 0; i < count; i++)
            {
                stack.Pop();
            }
            return (DateTime.Now.Subtract(startTime));
        }

        public override string ToString()
        {
            double adding = AddTimer().TotalSeconds;
            double reading = ReadTimer().TotalSeconds;
            return $"Adding={adding} sec; Reading={reading} sec; Deleting={reading} sec;\r\n";
        }
    }
}
