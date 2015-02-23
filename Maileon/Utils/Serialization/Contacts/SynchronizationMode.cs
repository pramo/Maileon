using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Utils.Serialization.Contacts
{
    /// <summary>
    /// Maileon Contact Syncronization modes
    /// </summary>
    public enum XmlSynchronizationMode
    {
        [XmlEnum("1")]
        Update = 1,
        [XmlEnum("2")]
        Ignore = 2
    }
}
