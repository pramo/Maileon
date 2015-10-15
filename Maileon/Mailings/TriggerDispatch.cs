using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    public enum TriggerDispatchTypes
    {
        [XmlEnum("MULTI")]
        Multi,
        [XmlEnum("SINGLE")]
        Single
    }

    public enum TriggerDispatchTargets
    {
        [XmlEnum("EVENT")]
        Event,
        [XmlEnum("CONTACTFILTER")]
        ContactFilter
    }

    public enum TriggerDispatchSpeedLevels
    {
        [XmlEnum("LOW")]
        Low,
        [XmlEnum("MEDIUM")]
        Medium,
        [XmlEnum("HIGH")]
        High
    }

    public enum TriggerDispatchIntervals
    {
        [XmlEnum("HOUR")]
        Hour,
        [XmlEnum("DAY")]
        Day,
        [XmlEnum("WEEK")]
        Week,
        [XmlEnum("MONTH")]
        Month
    }
}
