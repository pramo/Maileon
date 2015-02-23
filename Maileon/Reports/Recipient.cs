using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class representing an email received event in Maileon
    /// </summary>
    [XmlRoot("recipient")]
    public class Recipient : AbstractEvent
    {
        /// <summary>
        /// The email client of the recipient
        /// </summary>
        [XmlElement("client")]
        public EmailClient EmailClient { get; set; }
    }
}
