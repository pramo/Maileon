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
    [XmlRoot("attachments")]
    internal class AttachmentCollection
    {
        public AttachmentCollection() { Items = new List<Attachment>(); }
        public AttachmentCollection(List<Attachment> items) { Items = items; }

        [XmlElement("attachment")]
        public List<Attachment> Items { get; set; }

        public static implicit operator List<Attachment>(AttachmentCollection c)
        {
            return c.Items;
        }

        public static implicit operator AttachmentCollection(List<Attachment> c)
        {
            return new AttachmentCollection(c);
        }
    }
}
