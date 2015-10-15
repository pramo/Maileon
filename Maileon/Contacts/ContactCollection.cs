using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Contacts
{
    /// <summary>
    /// A class for wrapping a list of contacts
    /// </summary>
    [XmlRoot("contacts")]
    internal class ContactCollection
    {
        public ContactCollection() { Items = new List<Contact>(); }
        public ContactCollection(List<Contact> items) { Items = items; }

        [XmlElement("contact")]
        public List<Contact> Items { get; set; }

        public static implicit operator List<Contact>(ContactCollection c)
        {
            return c.Items;
        }

        public static implicit operator ContactCollection(List<Contact> c)
        {
            return new ContactCollection(c);
        }
    }
}
