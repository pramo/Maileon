using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    /// <summary>
    /// A class for wrapping a list of links
    /// </summary>
    [XmlRoot("links")]
    internal class LinkCollection
    {
        public LinkCollection() { Items = new List<Link>(); }
        public LinkCollection(List<Link> items) { Items = items; }

        [XmlElement("link")]
        public List<Link> Items { get; set; }

        public static implicit operator List<Link>(LinkCollection c)
        {
            return c.Items;
        }

        public static implicit operator LinkCollection(List<Link> c)
        {
            return new LinkCollection(c);
        }
    }
}
