using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Contacts
{
    /// <summary>
    /// A class to represent Maileon synchronization reports
    /// </summary>
    [XmlRoot("report")]
    public class SynchronizationReport
    {
        /// <summary>
        /// Whether the synchronization was successful
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

        /// <summary>
        /// The number of contacts in this synchronization
        /// </summary>
        [XmlElement("count_contacts")]
        public int CountContacts { get; set; }

        /// <summary>
        /// The number of newly created contacts
        /// </summary>
        [XmlElement("count_new_contacts")]
        public int CountNewContacts { get; set; }

        /// <summary>
        /// The number of already existing contacts
        /// </summary>
        [XmlElement("count_existing_contacts")]
        public int CountExistingContacts { get; set; }

        /// <summary>
        /// The number of invalid contacts
        /// </summary>
        [XmlElement("count_invalid_contacts")]
        public int CountInvalidContacts { get; set; }

        /// <summary>
        /// The invalid contacts of this synchronization
        /// </summary>
        [XmlArray("invalid_contacts"), XmlArrayItem("contact")]
        public List<InvalidContact> InvalidContacts { get; set; }

        public SynchronizationReport() { }
    }
}
