using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Contacts
{
    /// <summary>
    /// Maileon Contact permissions
    /// </summary>
    public enum Permission
    {
        [XmlEnum("1")]
        None = 1,
        [XmlEnum("2")]
        SingleOptIn = 2,
        [XmlEnum("3")]
        ConfirmedOptIn = 3,
        [XmlEnum("4")]
        DoubleOptIn = 4,
        [XmlEnum("5")]
        DoubleOptInPlus = 5,
        [XmlEnum("6")]
        Other = 6
    }
}
