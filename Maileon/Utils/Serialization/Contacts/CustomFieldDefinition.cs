using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Utils.Serialization.Contacts
{
    /// <summary>
    /// A class for wrapping a maileon contact field definition
    /// </summary>
    [XmlRoot("custom_field")]
    public class XmlCustomFieldDefinition
    {
        /// <summary>
        /// The name of this custom field
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
        /// <summary>
        /// The type of this custom field
        /// </summary>
        [XmlElement("type")]
	    public XmlCustomFieldType Type { get; set; }

	    public XmlCustomFieldDefinition() { }
        public XmlCustomFieldDefinition(string name, XmlCustomFieldType type)
        {
		    this.Name = name;
		    this.Type = type;
	    }
    }
}
