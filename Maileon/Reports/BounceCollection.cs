using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class for wrapping a list of bounces
    /// </summary>
    [XmlRoot("bounces")]
    internal class BounceCollection
    {
        public BounceCollection() { Items = new List<Bounce>(); }
        public BounceCollection(List<Bounce> items) { Items = items; }

        [XmlElement("bounce")]
        public List<Bounce> Items { get; set; }

        public static implicit operator List<Bounce>(BounceCollection c)
        {
            return c.Items;
        }

        public static implicit operator BounceCollection(List<Bounce> c)
        {
            return new BounceCollection(c);
        }
    }
}
