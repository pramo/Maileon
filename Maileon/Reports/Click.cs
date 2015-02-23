using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class representing a click event in Maileon
    /// </summary>
    [XmlRoot("click")]
    public class Click : AbstractEvent
    {
        /// <summary>
        /// The URL for this click
        /// </summary>
        [XmlElement("link_url")]
        public string LinkUrl { get; set; }
        /// <summary>
        /// The ID of the link clicked
        /// </summary>
        [XmlElement("link_id")]
        public long LinkId { get; set; }
        /// <summary>
        /// The format of this click
        /// </summary>
        [XmlElement("format")]
        public MailingFormat Format { get; set; }
        /// <summary>
        /// The device type for this click
        /// </summary>
        [XmlElement("device_type")]
        public DeviceType DeviceType { get; set; }
        /// <summary>
        /// The email client for this click
        /// </summary>
        [XmlElement("client")]
        public EmailClient EmailClient { get; set; }
    }
}
