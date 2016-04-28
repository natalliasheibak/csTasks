using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task1
{
    class LogWriter
    {
        string path;

        public LogWriter()
        {
            path = Environment.CurrentDirectory+@"\log.txt";
        }

        public void Write(string text)
        {
            File.AppendAllText(path, text);
        }
    }
}
