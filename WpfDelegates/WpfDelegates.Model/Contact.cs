using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WpfDelegates.Model
{
    [XmlRoot("Contact")]
	public class Contact
	{
        [XmlElement]
        public string Id { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Lastname { get; set; }

        [XmlElement]
        public string Telephone { get; set; }

        [XmlElement]
        public string Address { get; set; }
        //public string City { get; set; }
	}
}
