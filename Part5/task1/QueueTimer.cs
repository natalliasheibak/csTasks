using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class QueueTimer:ITimer
    {
        Queue<int> queue;
        int count;
        public QueueTimer(Queue<int> queue, int count)
        {
            this.queue = queue;
            this.count = count;
        }

        public TimeSpan AddTimer()
        {
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                queue.Enqueue(i);
            }
            return (DateTime.Now.Subtract(startTime));
        }

        public TimeSpan ReadTimer()
        {
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                queue.Dequeue();
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
