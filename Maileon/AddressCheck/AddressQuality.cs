using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.AddressCheck
{
    [XmlRoot("qualityStatus")]
    public class AddressQuality
    {
        /// <summary>
        /// Whether the address was syntactically correct
        /// </summary>
        [XmlElement("syntax")]
        public Syntax Syntax { get; set; }
        /// <summary>
        /// Whether the address was syntactically correct with the given provider
        /// </summary>
        [XmlElement("extsyntax")]
        public bool ProviderSyntax { get; set; }
        /// <summary>
        /// Whether the address was syntactically correct with the given provider
        /// </summary>
        [XmlElement("domain")]
        public bool DomainExists { get; set; }
        /// <summary>
        /// Whether the test was actually performed or retrieved from SMTP cache.
        /// </summary>
        [XmlElement("checked")]
        public bool Checked { get; set; }
        /// <summary>
        /// The address is verified by SMTP requests to one of the domains mailservers.
        /// </summary>
        [XmlElement("address")]
        public AddressExistance Address { get; set; }
        /// <summary>
        /// Domain name input in e-mail address forms often results in typos, and this check tries to find such errors. 
        /// </summary>
        [XmlElement("probability")]
        public bool NoAddressError { get; set; }
        /// <summary>
        /// The aggregated risk that an e-mail to this domain/address will be rejected, bounce.
        /// </summary>
        [XmlElement("bounceRisk")]
        public bool NoBounceRisk { get; set; }
        /// <summary>
        /// Not all mailserver tell the truth about the existence of an e-mail address, mostly due to anti-spam measures. The mailserverDiagnosis element describes the response behaviour of the domains mailservers to SMTP requests.
        /// </summary>
        [XmlElement("mailserverDiagnosis")]
        public MailserverDiagnosis MailserverDiagnosis { get; set; }
        /// <summary>
        /// If the domain exists, the system checks also whether the domain has a mail server defined. also by checking the DNS record.
        /// </summary>
        [XmlElement("mailserver")]
        public bool MailserverExists { get; set; }
        /// <summary>
        /// The domainScores element consists of a list of similar sounding domain names ordered by a calculated score
        /// </summary>
        [XmlElement("domainScores")]
        public DomainScoreCollection DomainScores { get; set; }

        [XmlElement("decoded")]
        public string DecodedAddress { get; set; }
    }
}
