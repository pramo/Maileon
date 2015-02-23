using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.AddressCheck
{
    [XmlRoot("domainScore")]
    public class DomainScore
    {
        [XmlElement("score")]
        public float Score { get; set; }
        [XmlElement("value")]
        public string Value { get; set; }
    }
}
