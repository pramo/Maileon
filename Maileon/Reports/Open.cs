using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A Class representing an open event in Maileon
    /// </summary>
    [XmlRoot("open")]
    public class Open : AbstractEvent
    {
        /// <summary>
        /// The format for this open
        /// </summary>
        [XmlElement("format")]
        public MailingFormat Format { get; set; }
        /// <summary>
        /// The device type for this open
        /// </summary>
        [XmlElement("device_type")]
        public DeviceType DeviceType { get; set; }
        /// <summary>
        /// The email client for this open
        /// </summary>
        [XmlElement("client")]
        public EmailClient EmailClient { get; set; }
    }
}
