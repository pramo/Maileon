using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Utils.Serialization.Contacts
{
    public enum XmlCustomFieldType
    {
        [XmlEnum("string")]
        String,
        [XmlEnum("integer")]
        Integer,
        [XmlEnum("boolean")]
        Boolean,
        [XmlEnum("float")]
        Float,
        [XmlEnum("date")]
        Date
    }
}
