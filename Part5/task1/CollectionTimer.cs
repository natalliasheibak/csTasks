using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class CollectionTimer: ICollectionDictionaryTimer
    {
        ICollection<int> collection;
        int count;
        public CollectionTimer(List<int> collection, int count)
        {
            this.collection = collection as List<int>;
            this.count = count;
        }

        public CollectionTimer(LinkedList<int> collection, int count)
        {
            this.collection = collection as LinkedList<int>;
            this.count = count;
        }

        public CollectionTimer(SortedSet<int> collection, int count)
        {
            this.collection = collection as SortedSet<int>;
            this.count = count;
        }

        public TimeSpan AddTimer()
        {
            DateTime startTime = DateTime.Now;
            for(int i = 0; i < count; i++)
            {
                collection.Add(i);
            }
            DateTime endTime = DateTime.Now;
            return (endTime.Subtract(startTime));
        }

        public TimeSpan ReadTimer()
        {
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                int element=collection.ElementAt(i);
            }
            DateTime endTime = DateTime.Now;
            return (endTime.Subtract(startTime));
        }

        public TimeSpan RemoveTimer()
        {
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                collection.Remove(i);
            }
            DateTime endTime = DateTime.Now;
            return (endTime.Subtract(startTime));
        }

        public override string ToString()
        {
            return $"Adding={AddTimer().TotalSeconds} sec; Reading={ReadTimer().TotalSeconds} sec; Deleting={RemoveTimer().TotalSeconds} sec;\r\n";
        }
    }
}
