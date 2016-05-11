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
            string inputFile = "books.xml";
            string outputFile = "book_ser.xml";
            Console.WriteLine("Deserialization is in progress...");
            var serializer = new XmlSerializer(typeof(Catalog));
            var catalog = serializer.Deserialize(new FileStream(inputFile, FileMode.Open)) as Catalog;
            if (catalog != null)
            {
                Console.WriteLine($"Deserialization of the file {inputFile} is successful\n"+
                                    "Serialization is in progress...");
                var stream = new FileStream(outputFile, FileMode.Create);
                serializer.Serialize(stream, catalog);
                Console.WriteLine("Serialization is complete");
                stream.Close();
            }
            else
            {
                Console.WriteLine($"Deserialization wasn't successful. Check your file for errors");
            }


        }
    }
}
