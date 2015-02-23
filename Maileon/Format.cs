using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon
{
    /// <summary>
    /// The valid formats of an email
    /// </summary>
    public enum MailingFormat
    {
        [XmlEnum("html")]
        HTML,
        [XmlEnum("text")]
        Text
    }
}
