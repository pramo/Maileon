using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    public enum MailingStates
    {
        [XmlEnum("draft")]
        Draft,
        [XmlEnum("failed")]
        Failed,
        [XmlEnum("queued")]
        Queued,
        [XmlEnum("checks")]
        Checks,
        [XmlEnum("blacklist")]
        Blacklist,
        [XmlEnum("preparing")]
        Preparing,
        [XmlEnum("sending")]
        Sending,
        [XmlEnum("canceled")]
        Canceled,
        [XmlEnum("paused")]
        Paused,
        [XmlEnum("done")]
        Done,
        [XmlEnum("archiving")]
        Archiving,
        [XmlEnum("archived")]
        Archived,
        [XmlEnum("released")]
        Released
    }
}
