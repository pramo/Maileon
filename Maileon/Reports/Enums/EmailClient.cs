using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class representing information about an email client
    /// </summary>
    public class EmailClient
    {
        /// <summary>
        /// The browser
        /// </summary>
        [XmlElement("browser")]
        public string Browser { get; set; }
        /// <summary>
        /// The browser group
        /// </summary>
        [XmlElement("browser_group")]
        public string BrowserGroup { get; set; }
        /// <summary>
        /// The browser version
        /// </summary>
        [XmlElement("browser_version")]
        public string BrowserVersion { get; set; }
        /// <summary>
        /// The type of the browser
        /// </summary>
        [XmlElement("browser_type")]
        public string BrowserType { get; set; }
        /// <summary>
        /// The rendering engine
        /// </summary>
        [XmlElement("rendering_engine")]
        public string RenderingEngine { get; set; }
        /// <summary>
        /// The User-Agent string
        /// </summary>
        [XmlElement("user_agent")]
        public string UserAgent { get; set; }
        /// <summary>
        /// The name of the OS
        /// </summary>
        [XmlElement("os_name")]
        public string OsName { get; set; }
        /// <summary>
        /// The gorup of the OS
        /// </summary>
        [XmlElement("os_group")]
        public string OsGroup { get; set; }

        public EmailClient() { }
    }
}
