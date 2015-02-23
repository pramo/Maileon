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
    [XmlRoot("attachment")]
    public class Attachment
    {
        /// <summary>
        /// The Maileon ID of this attachment
        /// </summary>
        [XmlElement("id")]
		public long Id { get; set; }
        /// <summary>
        /// The displayed filename of this attachment
        /// </summary>
        [XmlElement("filename")]
        public string Filename { get; set; }
        /// <summary>
        /// The size of the attachment
        /// </summary>
        [XmlElement("sizekb")]
		public long SizeKB { get; set; }
        /// <summary>
        /// The diagnosis of the attachment
        /// </summary>
        [XmlElement("diagnosis")]
		public string Diagnosis { get; set; }
        /// <summary>
        /// The MIME type of the attachment
        /// </summary>
        [XmlElement("mime_type")]
		public string MimeType { get;set;}
        /// <summary>
        /// The creation date of this attachment
        /// </summary>
        [XmlElement("created")]
		public Timestamp Created { get; set; }
        /// <summary>
        /// The last update date of this attachment
        /// </summary>
        [XmlElement("updated")]
		public Timestamp Updated { get; set; }

        public Attachment() { }
    }
}
