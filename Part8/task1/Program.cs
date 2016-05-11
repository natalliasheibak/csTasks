using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(Catalog));
            var catalog = serializer.Deserialize(new FileStream("books.xml", FileMode.Open)) as Catalog;

            var stream = new FileStream("ser1.xml", FileMode.Create);
            serializer.Serialize(stream, catalog);
            stream.Close();
        }
    }
}
