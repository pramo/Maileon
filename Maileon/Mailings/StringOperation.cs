using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    public enum StringOperation
    {
        [XmlEnum("contains")]
        Contains,
        [XmlEnum("equals")]
        Equals,
        [XmlEnum("starts_with")]
        StartsWith,
        [XmlEnum("ends_with")]
        EndsWith
    }
}
