using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    public enum Order
    {
        [XmlEnum("ASC")]
        Ascending,
        [XmlEnum("DESC")]
        Descending
    }
}
