using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dto
{
    [XmlType("user")]
    public class UserDto
    {
        [XmlAttribute(AttributeName = "firstName", Namespace = null)]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public int? Age { get; set; }

        [XmlArray("sold-products")]
        public SoldProductsCount[] SoldProducts { get; set; }
    }
}
