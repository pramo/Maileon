using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Blacklists
{
    /// <summary>
    /// A class for wrapping a list of blacklists
    /// </summary>
    [XmlRoot("blacklists")]
    internal class BlacklistCollection
    {
        public BlacklistCollection() { Items = new List<Blacklist>(); }
        public BlacklistCollection(List<Blacklist> items) { Items = items; }

        [XmlElement("blacklist")]
        public List<Blacklist> Items { get; set; }

        public static implicit operator List<Blacklist>(BlacklistCollection c)
        {
            return c.Items;
        }

        public static implicit operator BlacklistCollection(List<Blacklist> c)
        {
            return new BlacklistCollection(c);
        }
    }
}
