using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Contactfilters
{
    /// <summary>
    /// A class for wrapping a list of contacts
    /// </summary>
    [XmlRoot("contactfilters")]
    internal class ContactFilterCollection
    {
        public ContactFilterCollection() { Items = new List<ContactFilter>(); }
        public ContactFilterCollection(List<ContactFilter> items) { Items = items; }

        [XmlElement("contactfilter")]
        public List<ContactFilter> Items { get; set; }

        public static implicit operator List<ContactFilter>(ContactFilterCollection c)
        {
            return c.Items;
        }

        public static implicit operator ContactFilterCollection(List<ContactFilter> c)
        {
            return new ContactFilterCollection(c);
        }
    }
}
