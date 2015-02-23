using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Utils.Serialization.Contacts
{
    /// <summary>
    /// A class for wrapping a list of CustomContactFieldDefinitions
    /// </summary>
    [XmlRoot("custom_fields")]
    internal class XmlCustomFieldDefinitionCollection
    {
        public XmlCustomFieldDefinitionCollection() { Items = new List<XmlCustomFieldDefinition>(); }
        public XmlCustomFieldDefinitionCollection(List<XmlCustomFieldDefinition> items) { Items = items; }

        [XmlElement("custom_field")]
        public List<XmlCustomFieldDefinition> Items { get; set; }

        public static implicit operator List<XmlCustomFieldDefinition>(XmlCustomFieldDefinitionCollection c)
        {
            return c.Items;
        }

        public static implicit operator XmlCustomFieldDefinitionCollection(List<XmlCustomFieldDefinition> c)
        {
            return new XmlCustomFieldDefinitionCollection(c);
        }
    }
}
