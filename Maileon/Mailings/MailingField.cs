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

        /// <summary>
        /// Returns the actual value of this field
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            switch (Name)
            {
                case MailingFieldNames.Type:
                    return MaileonEnums.FromXmlString<MailingTypes>(Value);
                case MailingFieldNames.ScheduleTime:
                    return new Timestamp(Value);
                case MailingFieldNames.State:
                    return MaileonEnums.FromXmlString<MailingStates>(Value);
                default:
                    return Value;
            }
        }


        public MailingField() { }
    }
}
