using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

using Maileon.Utils;

namespace Maileon.Contacts
{
    /// <summary>
    /// Class representing a blocked contact in Maileon
    /// </summary>
    public class BlockedContact : Contact
    {
        /// <summary>
        /// The reason for the blocking
        /// </summary>
        [XmlElement("blocking_reason")]
        public string BlockingReason { get; set; }
        /// <summary>
        /// The timestamp of the blocking
        /// </summary>
        [XmlElement("blocking_timestamp")]
        public Timestamp BlockingTimestamp { get; set; }

        public BlockedContact() { }

    }
}
