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
        public FieldType Name { get; set; }
        [XmlElement("value")]
        public string Value { get; set; }

        /// <summary>
        /// Returns the actual value of this field
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            switch (Name)
            {
                case FieldType.Type:
                    return MaileonEnums.FromXmlString<MailingType>(Value);
                case FieldType.ScheduleTime:
                    return new Timestamp(Value);
                case FieldType.State:
                    return MaileonEnums.FromXmlString<MailingState>(Value);
                default:
                    return Value;
            }
        }


        public MailingField() { }
    }
}
