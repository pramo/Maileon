using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// The list of valid unsubscription sources
    /// </summary>
    public enum UnsubscriptionSource
    {
        [XmlEnum("link")]
        Link,
        [XmlEnum("reply")]
        Reply
    }
}
