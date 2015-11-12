using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.AddressCheck
{
    public enum AddressExistance
    {
        [XmlEnum("0")]
        NonExtistant = 0,
        [XmlEnum("1")]
        Exists = 1,
        [XmlEnum("2")]
        NotVerifiable = 2,
        [XmlEnum("-1")]
        TemporaryError = -1
    }
}
