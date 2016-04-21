using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class InfoPage : Page
    {
        public TextBox Age { get; private set; }
        public TextBox Name { get; private set; }
        public Button SaveButton { get; private set; }

        public override void LoadPage()
        {
            throw new NotImplementedException();
        }
    }
}
