using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    /// <summary>
    /// A class for wrapping a Maileon replyto address
    /// </summary>
    [XmlRoot("reply_to")]
    public class ReplyToAddress
    {
        public ReplyToAddress() { }

        /// <summary>
        /// This indicates if autorecognition af manual unsubscribers is activated in this account. 
        /// This should always be true.
        /// </summary>
        [XmlElement("active")]
        public bool Active { get; set; }

        /// <summary>
        /// This parameter indicates if messages are sorted internally by Maileons VERP technology 
        /// and provided to customery by a webinterface.
        /// </summary>
        [XmlElement("auto")]
        public bool Auto { get; set; }

        /// <summary>
        /// If auto is false, the replies will be forwarded to this address.
        /// </summary>
        [XmlElement("customEmail")]
        public string CustomEmail { get; set; }
    }
}
