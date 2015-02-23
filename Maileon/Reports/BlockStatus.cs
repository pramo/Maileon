using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// The status of this block
    /// </summary>
    public enum BlockStatus
    {
        [XmlEnum("allowed")]
        Allowed,
        [XmlEnum("blocked")]
        Blocked
    }
}
