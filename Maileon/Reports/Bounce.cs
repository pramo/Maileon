using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class representing a bounce venet in Maileon
    /// </summary>
    public class Bounce : AbstractEvent
    {
        /// <summary>
        /// The status code of this bounce
        /// </summary>
        [XmlElement("status_code")]
        public BounceCode StatusCode { get; set; }
        /// <summary>
        /// The type of this bounce
        /// </summary>
        [XmlElement("type")]
        public BounceType Type { get; set; }
        /// <summary>
        /// The source of this bounce
        /// </summary>
        [XmlElement("source")]
        public BounceSource Source { get; set; }

    }
}
