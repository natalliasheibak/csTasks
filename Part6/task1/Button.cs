using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Button:IClickable
    {
        public bool Enabled { get; set; }
        public string Name { get; private set; }

        public Button(string name, bool enabled)
        {
            this.Name = name;
            this.Enabled = enabled;
        }

        public string Click()
        {
            if (Enabled)
            {
                return $"The name of the element={this.Name}";
            }
            else
            {
                //если кнопка имеет статус Disabled - бросить исключение ElementDisabledException
                throw new ElementDisabledException($"The element {this.Name} is disabled");
            }
        }
    }
}
