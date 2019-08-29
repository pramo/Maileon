using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Contacts
{
    /// <summary>
    /// A class for wrapping a list of CustomContactFieldDefinitions
    /// </summary>
    [XmlRoot("custom_fields")]
    public class CustomFieldDefinitionCollection
    {
        public CustomFieldDefinitionCollection() { Items = new List<CustomFieldDefinition>(); }
        public CustomFieldDefinitionCollection(List<CustomFieldDefinition> items) { Items = items; }

        [XmlElement("custom_field")]
        public List<CustomFieldDefinition> Items { get; set; }

        public static implicit operator List<CustomFieldDefinition>(CustomFieldDefinitionCollection c)
        {
            return c.Items;
        }

        public static implicit operator CustomFieldDefinitionCollection(List<CustomFieldDefinition> c)
        {
            return new CustomFieldDefinitionCollection(c);
        }
    }
}
