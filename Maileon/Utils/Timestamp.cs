using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Utils
{
    /// <summary>
    /// A helper class for parsing and converting Maileon/Java timestamps
    /// </summary>
    public class Timestamp
    {
        /// <summary>
        /// This is the string representation of the date used by the Maileon API
        /// </summary>
        [XmlText]
        public string Value 
        {
            get
            {
                return this.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                this.DateTime = DateTime.Parse(value);
            }
        }

        /// <summary>
        /// The .NET DateTime object representation of this date
        /// </summary>
        public DateTime DateTime { get; set; }

        private static DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Returns the milliseconds passed since the UNIX epoch (Java long time)
        /// </summary>
        [XmlIgnore]
        public long TimeInMillis
        {
            get
            {
                return (long)unixEpoch.Subtract(this.DateTime).TotalMilliseconds;
            }
            private set { }
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator DateTime(Timestamp t)
        {
            return t.DateTime;
        }

        public static implicit operator Timestamp(DateTime d)
        {
            return new Timestamp(d);
        }

        public Timestamp() { }
        public Timestamp(DateTime d)
        {
            this.DateTime = d;
        }
        public Timestamp(string s)
        {
            this.DateTime = DateTime.Parse(s);
        }
    }
}
