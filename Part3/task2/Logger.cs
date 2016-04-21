using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Logger
    {
        private string _name;
        private int _age;

        public string Name { get; set; }
        public int Age { get; set; }

        public Logger(string name, int age)
        {
            this._name = name;
            this._age = age;
        }
    }
}
