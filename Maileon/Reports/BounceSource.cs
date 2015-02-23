using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// The valid bounce sources
    /// </summary>
    public enum BounceSource
    {
        [XmlEnum("mta-listener")]
        MtaListener,
        [XmlEnum("reply")]
        Reply
    }
}
