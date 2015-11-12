using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.AddressCheck
{
    public enum Syntax
    {
        [XmlEnum("0")]
        Invalid = 0,
        [XmlEnum("1")]
        Valid = 1,
        [XmlEnum("2")]
        Decoded = 2
    }
}
