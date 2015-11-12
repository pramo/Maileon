using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.AddressCheck
{
    public enum MailserverDiagnosis
    {
        [XmlEnum("0")]
        Unknown = 0,
        [XmlEnum("1")]
        Truthful = 1,
        [XmlEnum("2")]
        AlwaysConfirms = 2,
        [XmlEnum("3")]
        AlwaysDenies = 3,
        [XmlEnum("4")]
        Error = 4
    }
}
