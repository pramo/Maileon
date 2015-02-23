using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Utils.Serialization.Contacts
{
    public enum XmlFieldType
    {
        [XmlEnum("standard")]
        Standard,
        [XmlEnum("custom")]
        Custom,
        [XmlEnum("event")]
        Event
    }
}
