using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class for wrapping a list of clicks
    /// </summary>
    [XmlRoot("clicks")]
    internal class ClickCollection
    {
        public ClickCollection() { Items = new List<Click>(); }
        public ClickCollection(List<Click> items) { Items = items; }

        [XmlElement("click")]
        public List<Click> Items { get; set; }

        public static implicit operator List<Click>(ClickCollection c)
        {
            return c.Items;
        }

        public static implicit operator ClickCollection(List<Click> c)
        {
            return new ClickCollection(c);
        }
    }
}
