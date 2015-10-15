using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    public class Mailing
    {
        [XmlElement("id")]
        public long Id;
        [XmlElement("fields")]
        public List<MailingField> Fields;

        public Mailing() { }
    }
}
