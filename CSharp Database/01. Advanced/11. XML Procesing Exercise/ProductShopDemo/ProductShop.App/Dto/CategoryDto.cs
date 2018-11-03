using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dto
{
    [XmlType("category")]
    public class CategoryDto
    {
        [MinLength(3), MaxLength(15)]
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
