using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Contacts
{
    /// <summary>
    /// A class for wrapping a maileon contact
    /// </summary>
    [XmlRoot("contact")]
    public class Contact
    {
        /// <summary>
        /// The MaileonID for the contact
        /// </summary>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// Whether the serialized object should containt the ID
        /// </summary>
        [XmlIgnore]
        public bool IdSpecified { get; set; }

        /// <summary>
        /// The email address for the contact
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// The standard contact fields
        /// </summary>
        [XmlArray("standard_fields"), XmlArrayItem("field")]
        public List<StandardField> StandardFields { get; set; }

        /// <summary>
        /// The custom contact fields
        /// </summary>
        [XmlArray("custom_fields"), XmlArrayItem("field")]
        public List<CustomField> CustomFields { get; set; }

        /// <summary>
        /// The external ID of the contact
        /// </summary>
        [XmlElement("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// Whether the serialized object should containt the external ID
        /// </summary>
        [XmlIgnore]
        public bool ExternalIdSpecified { get; set; }

        /// <summary>
        /// The permission of the contact
        /// </summary>
        [XmlElement("permission")]
        public Permissions Permission { get; set; }

        /// <summary>
        /// Setting this to false will disable serialization of the Permission element
        /// </summary>
        [XmlIgnore]
        public bool PermissionSpecified { get; set; }

        /// <summary>
        /// Whether the contact's history has been anonymized
        /// </summary>
        [XmlIgnore]
        public bool Anonymous { get; set; }

        /// <summary>
        /// Get a value purely for serialization purposes
        /// </summary>
        [XmlElement("anonymous")]
        public string SerializeAnonymous
        {
            get { return this.Anonymous ? "1" : "0"; }
            set { this.Anonymous = value == "1"; }
        }

        [XmlIgnore]
        public bool SerializeAnonymousSpecified { get; set; }

        public Contact() { }
        public Contact(string email) 
        {
            this.Email = email;
            this.Permission = Permissions.None;
            this.StandardFields = new List<StandardField>();
            this.CustomFields = new List<CustomField>();

            this.PermissionSpecified = true;
            this.ExternalIdSpecified = true;
            this.IdSpecified = true;
        }
    }

}
