using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.AddressCheck
{
    [XmlRoot("domainScores")]
    public class DomainScoreCollection
    {
        [XmlElement("domainScore")]
        public List<DomainScore> Items { get; set; }
    }
}
