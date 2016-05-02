using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Page
    {
        public Dictionary<string,Button> buttons { get; set; }

        public Page()
        {

            buttons = new Dictionary<string, Button>();
        }

        public Page(Dictionary<string, Button> buttons)
        {
            buttons = new Dictionary<string, Button>();
            foreach (var button in buttons)
            {
                this.buttons.Add(button.Key,button.Value);
            }
        }
    }
}
