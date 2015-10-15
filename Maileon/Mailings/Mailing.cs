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

        private List<MailingField> _fields = new List<MailingField>();

        [XmlArray("fields"), XmlArrayItem("field")]
        public List<MailingField> Fields { get; set; }

        public object GetField(MailingFieldNames name)
        {
            return Fields.Find(field => field.Name == name).GetValue();
        }

        public Mailing() { }
    }
}
