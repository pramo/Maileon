using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Utils.Serialization.Contacts
{
    /// <summary>
    /// A class for wrapping a list of contacts
    /// </summary>
    [XmlRoot("contacts")]
    internal class XmlContactCollection
    {
        public XmlContactCollection() { Items = new List<XmlContact>(); }
        public XmlContactCollection(List<XmlContact> items) { Items = items; }

        [XmlElement("contact")]
        public List<XmlContact> Items { get; set; }

        public static implicit operator List<XmlContact>(XmlContactCollection c)
        {
            return c.Items;
        }

        public static implicit operator XmlContactCollection(List<XmlContact> c)
        {
            return new XmlContactCollection(c);
        }
    }
}
