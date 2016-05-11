using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace task1
{
    [XmlRoot("catalog", Namespace = "http://library.by/catalog")]
    public class Catalog
    {
        [XmlAttribute("date",DataType = "date")]
        public DateTime Date { get; set; }
        [XmlElement("book")]
        public List<Book> books;
    }
}
