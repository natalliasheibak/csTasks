using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XDocument pageData = XDocument.Load(Environment.CurrentDirectory + @"\Data\PageData.xml");
                var buttons = (from button in pageData.Element("page").Element("elements").Elements("button")
                               select button.Attribute("name").Value).ToList();     //Выгрузка кнопок из файла PageData.xml
                Page page = LoadElements.Load();    //Загрузка страницы из файлов
                bool isChosen = true;       
                Console.WriteLine("Type= \"s\" to see all elements of the page, or \"c\" to click on all elements of the page");

                while (isChosen)
                {
                    switch (Console.ReadLine())
                    {
                        //Кликание по всем кнопкам
                        case "c":
                            foreach (var button in buttons)
                            {
                                try
                                {
                                    Console.WriteLine(page.buttons[button].Click());
                                }
                                //Если кнопка недоступна, возникает исключение
                                catch (ElementDisabledException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                //Если кнопка не существует на странице
                                catch (KeyNotFoundException e)
                                {
                                    Console.WriteLine($"The element {button} does not exist on this page");
                                }
                            }
                            isChosen = false;
                            break;
                        //Отображение списка кнопок на странице
                        case "s":
                            foreach (var button in buttons)
                            {
                                Console.WriteLine(button);
                            }
                            isChosen = false;
                            break;

                        default:
                            Console.WriteLine("Type= \"s\" to see all elements of the page, or \"c\" to click on all elements of the page");
                            break;
                    }
                }
                Console.ReadLine();
            }
            //Если файл не существует
            catch(FileNotFoundException e)
            {
                Console.WriteLine("The xml file with data is not found");
            }
            //Если файл содержит некорректную информацию
            catch(NullReferenceException e)
            {
                Console.WriteLine("Incorrect format of the file with data");
            }
        }        
    }
}
