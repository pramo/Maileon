using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

using Maileon.Utils;

namespace Maileon.Reports
{
    /// <summary>
    /// An abstract event
    /// </summary>
    public abstract class AbstractEvent
    {
        /// <summary>
        /// The timestamp of this event
        /// </summary>
        [XmlElement("timestamp")]
        public Timestamp Timestamp { get; set; }
        /// <summary>
        /// The contact associated with this event
        /// </summary>
        [XmlElement("contact")]
        public ReportContact Contact { get; set; }
        /// <summary>
        /// The mailing ID associated with this event
        /// </summary>
        [XmlElement("mailing_id")]
        public NullableValue<long> MailingId { get; set; }

        public AbstractEvent()
        {
            this.MailingId = new NullableValue<long>();
        }
    }
}
