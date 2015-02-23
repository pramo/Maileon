using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Transactions
{
    /// <summary>
    /// A class for wrapping a list of contacts
    /// </summary>
    [XmlRoot("transaction_types")]
    internal class TransactionTypeCollection
    {
        public TransactionTypeCollection() { Items = new List<TransactionType>(); }
        public TransactionTypeCollection(List<TransactionType> items) { Items = items; }

        [XmlElement("transaction_type")]
        public List<TransactionType> Items { get; set; }

        public static implicit operator List<TransactionType>(TransactionTypeCollection c)
        {
            return c.Items;
        }

        public static implicit operator TransactionTypeCollection(List<TransactionType> c)
        {
            return new TransactionTypeCollection(c);
        }
    }
}
