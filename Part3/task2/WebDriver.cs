using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace task2
{
    class WebDriver
    {
        public enum Browser
        {
            Firefox,
            Chrome,
            Opera,
            IE,
            Safari
        }
        public void CheckBrowser()
        {
            string confBrowser = ConfigurationManager.AppSettings["browser"];
            Browser browser = (Browser)Enum.Parse(typeof(Browser), confBrowser);
            switch (browser)
            {
                case Browser.Chrome:
                    //todo
                    break;

                case Browser.Firefox:
                    //todo
                    break;

                case Browser.IE:
                    //todo
                    break;

                case Browser.Opera:
                    //todo
                    break;

                case Browser.Safari:
                    //todo
                    break;

                default:
                    //todo
                    break;
            }
        }
    }
}
