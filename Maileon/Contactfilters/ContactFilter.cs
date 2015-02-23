using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

using Maileon.Utils;

namespace Maileon.Contactfilters
{
    /// <summary>
    /// A class used to store a contactfilter's information
    /// </summary>
    [XmlRoot("contactfilter")]
    public class ContactFilter
    {
        /// <summary>
        /// The email adress of the author of a contactfilter
        /// </summary>
        [XmlElement("author")]
        public string Author { get; set; }
        /// <summary>
        /// The number of contacts that match the filter
        /// </summary>
        [XmlElement("count_contacts")]
        public int CountContacts { get; set; }
        /// <summary>
        /// The number of rules in the filter
        /// </summary>
        [XmlElement("count_rules")]
        public int CountRules { get; set; }
        /// <summary>
        /// The date when the contactfilter was created
        /// </summary>
        [XmlElement("created")]
        public Timestamp Created { get; set; }
        /// <summary>
        /// The last date when the contactfilter was updated
        /// </summary>
        [XmlElement("updated")]
        public Timestamp Updated { get; set; }
        /// <summary>
        /// The ID of a contactfilter
        /// </summary>
        [XmlElement("id")]
        public long? Id { get; set; }
        /// <summary>
        /// The (display) name of a contactfilter
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
        /// <summary>
        /// The state of the contact filter
        /// </summary>
        [XmlElement("state")]
        public ContactFilterState State { get; set; }

        public ContactFilter() { }
        public ContactFilter(long id, string name) 
        {
            this.Id = id;
            this.Name = name;
        }
    }

}
