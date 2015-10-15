using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    public enum ScheduleState
    {
        [XmlEnum("unscheduled")]
        Unscheduled,
        [XmlEnum("scheduled")]
        Scheduled,
        [XmlEnum("fired")]
        Fired,
        [XmlEnum("misfired")]
        Misfired
    }
}
