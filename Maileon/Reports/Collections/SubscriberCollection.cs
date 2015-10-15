using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class for wrapping a list of subscribers
    /// </summary>
    [XmlRoot("subscribers")]
    internal class SubscriberCollection
    {
        public SubscriberCollection() { Items = new List<Subscriber>(); }
        public SubscriberCollection(List<Subscriber> items) { Items = items; }

        [XmlElement("subscriber")]
        public List<Subscriber> Items { get; set; }

        public static implicit operator List<Subscriber>(SubscriberCollection c)
        {
            return c.Items;
        }

        public static implicit operator SubscriberCollection(List<Subscriber> c)
        {
            return new SubscriberCollection(c);
        }
    }
}
