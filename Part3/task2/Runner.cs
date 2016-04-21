using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Runner
    {
        public void SaveInfo(Logger logger)
        {
            InfoPage page = new InfoPage();
            page.LoadPage();
            page.Name.SetText(logger.Name);
            page.Age.SetText(logger.Age.ToString());
            page.SaveButton.Click();
        }
    }
}
