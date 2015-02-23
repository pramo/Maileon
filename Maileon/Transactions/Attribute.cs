using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Transactions
{
    /// <summary>
    /// A class for wrapping Maileon transaciton attributes
    /// </summary>
    public class Attribute
    {
        /// <summary>
        /// The id of this transaction attribute
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// The name of this transaction attribute
        /// </summary>
        [XmlElement("name")]
        public string Name { get;set; }

        /// <summary>
        /// The type of this transaction attribute
        /// </summary>
        [XmlElement("type")]
        public AttributeType Type { get;set; }

        /// <summary>
        /// Whether this attribute is mandatory
        /// </summary>
        [XmlElement("required")]
        public bool Required { get;set; }
       
        public Attribute(AttributeType type, string name, bool required) { this.Type = type; this.Name = name; this.Required = required; }
        public Attribute(AttributeType type, string name) : this(type, name, false) { }
        public Attribute() { }

        public override string ToString()
        {
            return Name + " : " + Type;
        }
    }
}
