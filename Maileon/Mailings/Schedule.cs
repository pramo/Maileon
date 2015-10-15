using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

using Maileon.Utils;

namespace Maileon.Mailings
{
    /// <summary>
    /// A class encapsulating information about a Maileon attachment
    /// </summary>
    [XmlRoot("schedule")]
    public class Schedule
    {
        /// <summary>
        /// The minutes a mailing is scheduled for
        /// </summary>
        [XmlElement("minutes")]
        public int Minutes { get; set; }
        /// <summary>
        /// The hour a mailing is scheduled for
        /// </summary>
        [XmlElement("hours")]
        public int Hours { get; set; }
        /// <summary>
        /// The day the mailing is scheduled for
        /// </summary>
        [XmlElement("date")]
        public string Date { get; set; }
        /// <summary>
        /// The state of the scheduling
        /// </summary>
        [XmlElement("state")]
        public ScheduleState State { get; set; }

        public static implicit operator Timestamp(Schedule schedule)
        {
            return DateTime.Parse(
                string.Format("{0} {1:D2}:{2:D2}:00", 
                schedule.Date, schedule.Hours, schedule.Minutes));
        }

        public static implicit operator Schedule(Timestamp timestamp)
        {
            Schedule schedule = new Schedule();
            schedule.Date = timestamp.DateTime.ToString("yyyy-MM-dd");
            schedule.Hours = timestamp.DateTime.Hour;
            schedule.Minutes = timestamp.DateTime.Minute;

            return schedule;
        }

        public Schedule() { }
    }
}
