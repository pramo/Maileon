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
        public long Id { get; set; }

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

        public TransactionType() { }
        public TransactionType(string name) { this.Name = name; }

        public override string ToString()
        {
            return Name;
        }
    }
}
