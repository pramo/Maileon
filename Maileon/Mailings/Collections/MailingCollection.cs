using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    /// <summary>
    /// A class for wrapping a list of attachments
    /// </summary>
    [XmlRoot("mailings")]
    public class MailingCollection
    {
        public MailingCollection() { Items = new List<Mailing>(); }
        public MailingCollection(List<Mailing> items) { Items = items; }

        [XmlElement("mailing")]
        public List<Mailing> Items { get; set; }

        public static implicit operator List<Mailing>(MailingCollection c)
        {
            return c.Items;
        }

        public static implicit operator MailingCollection(List<Mailing> c)
        {
            return new MailingCollection(c);
        }
    }
}
