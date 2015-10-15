using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Contactfilters
{
    public enum ContactFilterState
    {
        [XmlEnum("outofdate")]
        OutOfDate,
        [XmlEnum("updating")]
        Updating,
        [XmlEnum("uptodate")]
        UpToDate
    }
}
