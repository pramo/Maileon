using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Transactions
{
    /// <summary>
    /// A class for wrapping Maileon transaction types
    /// </summary>
    [XmlRoot("transaction_type")]
    public class TransactionType
    {
        /// <summary>
        /// The id of this type
        /// </summary>
        [XmlElement("id")]
        public long? Id { get; set; }

        /// <summary>
        /// The name of this type
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// The attributes of this transaction
        /// </summary>
        [XmlArray("attributes"), XmlArrayItem("attribute")]
        public List<Attribute> Attributes { get; set; }

        /// <summary>
        /// Returns the attribute with the given name
        /// </summary>
        /// <returns></returns>
        public Attribute GetAttribute(string name)
        {
            return Attributes.Find(attribute => attribute.Name == name);
        }

        public TransactionType() { this.Attributes = new List<Attribute>(); }
        public TransactionType(string name) : this() { this.Name = name;  }

        public override string ToString()
        {
            return Name;
        }
    }
}
