using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    public enum SocialNetwork
    {
        [XmlEnum("DL")]
        Delicious,
        [XmlEnum("DG")]
        Digg,
        [XmlEnum("FB")]
        Facebook,
        [XmlEnum("GP")]
        GooglePlus,
        [XmlEnum("LI")]
        LinkedIn,
        [XmlEnum("MX")]
        Mixx,
        [XmlEnum("MY")]
        Myspace,
        [XmlEnum("RD")]
        Reddit,
        [XmlEnum("SV")]
        Studivz,
        [XmlEnum("SU")]
        Stumbleupon,
        [XmlEnum("TW")]
        Twitter,
        [XmlEnum("XG")]
        Xing,
        [XmlEnum("YG")]
        Yigg
    }
}
