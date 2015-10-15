using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class for wrapping a list of opens
    /// </summary>
    [XmlRoot("opens")]
    internal class OpenCollection
    {
        public OpenCollection() { Items = new List<Open>(); }
        public OpenCollection(List<Open> items) { Items = items; }

        [XmlElement("open")]
        public List<Open> Items { get; set; }

        public static implicit operator List<Open>(OpenCollection c)
        {
            return c.Items;
        }

        public static implicit operator OpenCollection(List<Open> c)
        {
            return new OpenCollection(c);
        }
    }
}
