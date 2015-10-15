using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Transactions
{
    /// <summary>
    /// Maileon transaction attribute types
    /// </summary>
    public enum AttributeType
    {
        [XmlEnum("string")]
        String,
        [XmlEnum("double")]
        Double,
        [XmlEnum("float")]
        Float,
        [XmlEnum("integer")]
        Integer,
        [XmlEnum("boolean")]
        Boolean,
        [XmlEnum("timestamp")]
        Timestamp,
        [XmlEnum("json")]
        Json,
        [XmlEnum("date")]
        Date
    }
}
