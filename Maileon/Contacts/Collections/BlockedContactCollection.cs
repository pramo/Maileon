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
    internal class BlockedContactCollection
    {
        public BlockedContactCollection() { Items = new List<BlockedContact>(); }
        public BlockedContactCollection(List<BlockedContact> items) { Items = items; }

        [XmlElement("contact")]
        public List<BlockedContact> Items { get; set; }

        public static implicit operator List<BlockedContact>(BlockedContactCollection c)
        {
            return c.Items;
        }

        public static implicit operator BlockedContactCollection(List<BlockedContact> c)
        {
            return new BlockedContactCollection(c);
        }
    }
}
