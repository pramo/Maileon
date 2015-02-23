using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    public enum SpeedLevel
    {
        [XmlEnum("low")]
        Low,
        [XmlEnum("medium")]
        Medium,
        [XmlEnum("high")]
        High,
        [XmlEnum("supersonic")]
        Supersonic
    }
}
