using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    [XmlRoot("dispatch_options")]
    public class TriggerDispatchOptions
    {
        /// <summary>
        /// The type of the trigger mail dispatch plan, this can be one of ‘SINGLE’ or ‘MULTI’.
        ///     SINGLE: The trigger mailing will be instantly sent when a given transaction event is received. 
        ///     MULTI: This represents an intervall scheduling where several contacts can receive the same(personalized) mailing at once.
        /// </summary>
        [XmlElement("type")]
        public TriggerDispatchTypes Type { get; set; }

        /// <summary>
        /// The ID of the transaction event that is used to either start the instant mailing or to controll the mass mailing.
        /// </summary>
        [XmlElement("event")]
        public long Event { get; set; }

        /// <summary>
        /// Defines the target group of a intervall mailing. This can either be ‘EVENT’ or ‘CONTACTFILTER’.
        ///     EVENT: Contacts are selected based on receiving a given transaction event.
        ///     CONTACTFILTER: Contacts are selected by using a given contact filter.
        /// </summary>
        [XmlElement("target")]
        public TriggerDispatchTargets Target { get; set; }

        /// <summary>
        /// Valid values are ‘LOW’, ‘MEDIUM’, and ‘HIGH’
        /// </summary>
        [XmlElement("speed_level")]
        public TriggerDispatchSpeedLevels Speed { get;set;}

        /// <summary>
        /// This defines the interval in which the mailing is sent. This can be one of ‘HOUR’, ‘DAY’, ‘WEEK’, or ‘MONTH’
        /// </summary>
        [XmlElement("interval")]
        public TriggerDispatchIntervals Interval { get; set; }

        /// <summary>
        /// Sets the day of the month the mailing will be sent.
        ///     Range: [1..31]
        ///     If you set a larger number than the month has days, the last day in the month will be used.
        /// </summary>
        [XmlElement("day_of_month")]
        public int DayOfMonth { get; set; }

        /// <summary>
        /// Sets the day of the week the mailing will be sent.
        ///     Range: [1..7]
        ///     1 = Sunday
        ///     2 = Monday
        ///     3 = Tuesday
        ///     4 = Wednesday
        ///     5 = Thursday
        ///     6 = Friday
        ///     7 = Saturday
        /// </summary>
        [XmlElement("day_of_week")]
        public int DayOfWeek { get; set; }

        /// <summary>
        /// Sets the tour of the day the mailing will be sent.
        ///     Range: [0..23]
        /// </summary>
        [XmlElement("hours")]
        public int Hours { get; set; }

        /// <summary>
        /// Sets the minute of the hour the mailing will be sent.
        ///     Range: [0..59]
        /// </summary>
        [XmlElement("minutes")]
        public int Minutes { get; set; }

        /// <summary>
        /// If set to true, the trigger will be instantly activated after setting the dispatching options.
        /// </summary>
        [XmlElement("start_trigger")]
        public bool StartTrigger { get; set; }
    }
}
