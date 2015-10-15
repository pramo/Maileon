using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class for wrapping a list of recipients
    /// </summary>
    [XmlRoot("recipients")]
    internal class RecipientCollection
    {
        public RecipientCollection() { Items = new List<Recipient>(); }
        public RecipientCollection(List<Recipient> items) { Items = items; }

        [XmlElement("recipient")]
        public List<Recipient> Items { get; set; }

        public static implicit operator List<Recipient>(RecipientCollection c)
        {
            return c.Items;
        }

        public static implicit operator RecipientCollection(List<Recipient> c)
        {
            return new RecipientCollection(c);
        }
    }
}
