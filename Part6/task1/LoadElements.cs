using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task1
{
    class LoadElements
    {
        public static Page Load()
        {
            try
            {
                Page page = new Page();
                XDocument pageData = XDocument.Load(Environment.CurrentDirectory + @"\Data\PageData.xml");
                XDocument buttonState = XDocument.Load(Environment.CurrentDirectory + @"\Data\ButtonState.xml");

                var buttons = (from button in pageData.Element("page").Element("elements").Elements("button")
                               select button).ToList();     //список всех кнопок из файла PageData.xml
                var buttonsWithStatus = buttonState.Element("buttonstate").Element("buttons").Elements("button").ToList();      //список всех кнопок из ButtonState.xml

                foreach (var button in buttons)
                {
                    try
                    {
                        //если в файле со статусом есть данная кнопка
                        if (buttonsWithStatus.Any(buttonName => buttonName.Attribute("name").Value == button.Attribute("name").Value))
                        {
                            page.buttons.Add(button.Attribute("name").Value, new Button(button.Attribute("name").Value, bool.Parse(buttonsWithStatus
                                                                                .Where(buttonStatus => buttonStatus.Attribute("name").Value == button.Attribute("name").Value)
                                                                                .Select(buttonStatus => buttonStatus.Value).Single())));    //создать ее на странице
                        }
                        //если нету, то бросить исключение
                        else 
                            {
                                throw new FormatException();
                            }
                        
                    }
                    //если в файле с статусом больше, чем одна кнопка обладает таким именем
                    catch(InvalidOperationException e)
                    {
                        Console.WriteLine($"The element {button.Attribute("name").Value} has more than one status");
                        continue;
                    }
                    //если в статусе некорректное значение или статуса вообще нет
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Incorrect status for the element {button.Attribute("name").Value} or the status is absent. The button wasn't added to the page ");
                        continue;
                    }
                }

                return page;
            }
            catch(FileNotFoundException e)
            {
                throw new FileNotFoundException();
            }
            catch(NullReferenceException e)
            {
                throw new NullReferenceException();
            }
        }
    }
}
