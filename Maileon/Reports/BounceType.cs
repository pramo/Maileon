using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// The valid bounce types
    /// </summary>
    public enum BounceType
    {
        [XmlEnum("permanent")]
        Permanent,
        [XmlEnum("transient")]
        Transient
    }
}
