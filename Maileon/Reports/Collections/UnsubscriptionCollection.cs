using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class for wrapping a list of unsubscriptions
    /// </summary>
    [XmlRoot("unsubscriptions")]
    internal class UnsubscriptionCollection
    {
        public UnsubscriptionCollection() { Items = new List<Unsubscription>(); }
        public UnsubscriptionCollection(List<Unsubscription> items) { Items = items; }

        [XmlElement("unsubscription")]
        public List<Unsubscription> Items { get; set; }

        public static implicit operator List<Unsubscription>(UnsubscriptionCollection c)
        {
            return c.Items;
        }

        public static implicit operator UnsubscriptionCollection(List<Unsubscription> c)
        {
            return new UnsubscriptionCollection(c);
        }
    }
}
