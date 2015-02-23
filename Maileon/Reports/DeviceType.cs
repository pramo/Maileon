using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// The valid device types
    /// </summary>
    public enum DeviceType
    {
        [XmlEnum("UNKNOWN")]
        Unknown,
        [XmlEnum("COMPUTER")]
        Computer,
        [XmlEnum("TABLET")]
        Tablet,
        [XmlEnum("MOBILE")]
        Mobile
    }
}
