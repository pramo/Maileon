using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    public enum FieldType
    {
        [XmlEnum("type")]
        Type,
        [XmlEnum("state")]
        State,
        [XmlEnum("name")]
        Name,
        [XmlEnum("scheduleTime")]
        ScheduleTime,
    }
}
