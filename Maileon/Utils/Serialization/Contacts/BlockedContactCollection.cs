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
    internal class XmlBlockedContactCollection
    {
        public XmlBlockedContactCollection() { Items = new List<XmlBlockedContact>(); }
        public XmlBlockedContactCollection(List<XmlBlockedContact> items) { Items = items; }

        [XmlElement("contact")]
        public List<XmlBlockedContact> Items { get; set; }

        public static implicit operator List<XmlBlockedContact>(XmlBlockedContactCollection c)
        {
            return c.Items;
        }

        public static implicit operator XmlBlockedContactCollection(List<XmlBlockedContact> c)
        {
            return new XmlBlockedContactCollection(c);
        }
    }
}
