using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

using Maileon.Utils;

namespace Maileon.Mailings
{
    public class MailingField
    {
        [XmlElement("name")]
        public MailingFieldNames Name { get; set; }
        [XmlElement("value")]
        public string Value { get; set; }

        public MailingField() { }
    }
}
