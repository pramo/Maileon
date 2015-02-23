using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Contacts
{
    /// <summary>
    /// A class for wrapping a maileon contact field definition
    /// </summary>
    [XmlRoot("custom_field")]
    public class CustomFieldDefinition
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
	    public CustomFieldType Type { get; set; }

	    public CustomFieldDefinition() { }
        public CustomFieldDefinition(string name, CustomFieldType type)
        {
		    this.Name = name;
		    this.Type = type;
	    }
    }
}
