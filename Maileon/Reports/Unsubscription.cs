using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class representing an unsubscription event in Maileon
    /// </summary>
    public class Unsubscription : AbstractEvent
    {
        /// <summary>
        /// The source of this unsubscription
        /// </summary>
        [XmlElement("source")]
        public UnsubscriptionSource Source { get; set;  }
    }
}
