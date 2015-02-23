using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    /// <summary>
    /// A class for encapsulating a Mailon link
    /// </summary>
    public class Link
    {
        /// <summary>
        /// The ID of this link
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }
        /// <summary>
        /// The format of this link
        /// </summary>
        [XmlElement("format")]
        public MailingFormat Format { get; set; }
        /// <summary>
        /// The layout of this link
        /// </summary>
        [XmlElement("layout")]
        public string Layout { get; set; }
        /// <summary>
        /// The URL that this link points to
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }
        /// <summary>
        /// The Maileon tags of this link
        /// </summary>
        [XmlArray("tags"), XmlArrayItem("tag")]
        public List<string> Tags { get; set; }

        public Link() { }
    }
}
