using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    public enum MailingTypes
    {
        [XmlEnum("doi")]
        Doi,
        [XmlEnum("regular")]
        Regular,
        [XmlEnum("trigger")]
        Trigger,
        [XmlEnum("trigger_draft")]
        TriggerDraft
    }
}
