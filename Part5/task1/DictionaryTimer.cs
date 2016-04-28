using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class DictionaryTimer: ICollectionDictionaryTimer
    {
        IDictionary<int, int> dictionary;
        int count;
        public DictionaryTimer(Dictionary<int, int> dictionary, int count)
        {
            this.dictionary = dictionary as Dictionary<int, int>;
            this.count = count;
        }

        public DictionaryTimer(SortedDictionary<int,int> dictionary, int count)
        {
            this.dictionary = dictionary as SortedDictionary<int, int>;
            this.count = count;
        }

        public TimeSpan AddTimer()
        {
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                dictionary.Add(i,i);
            }
            return (DateTime.Now.Subtract(startTime));
        }

        public TimeSpan ReadTimer()
        {
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                int element = dictionary[i];
            }
            return (DateTime.Now.Subtract(startTime));
        
        }

        public TimeSpan RemoveTimer()
        {
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                dictionary.Remove(i);
            }
            return (DateTime.Now.Subtract(startTime));
        }

        public override string ToString()
        {
            return $"Adding={AddTimer().TotalSeconds} sec; Reading={ReadTimer().TotalSeconds} sec; Deleting={RemoveTimer().TotalSeconds} sec;\r\n";
        }
    }
}
