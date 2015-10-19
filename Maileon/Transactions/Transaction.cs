using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Script.Serialization;
using System.Runtime.Serialization;

using Maileon.Utils;
using Maileon.Utils.JSON;

namespace Maileon.Transactions
{
    /// <summary>
    /// A class for wrapping Maileon JSON transactions
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The contact identification
        /// </summary>
        [MaileonJson("contact")]
        public ContactReference Contact { get; set; }

        /// <summary>
        /// Use this if the contact should be imported
        /// </summary>
        [MaileonJson("import")]
        public ImportReference Import { get; set; }

        /// <summary>
        /// The type id of this transaction
        /// </summary>
        [MaileonJson("type")]
        public long Type { get; set; }

        /// <summary>
        /// The content of this transaction
        /// </summary>
        [MaileonJson("content")]
        public object Content { get; set; }

        [MaileonJson("attachments")]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// Sets the content of the transaction from raw JSON data
        /// </summary>
        /// <param name="json">the raw JSON data to set for this transaction</param>
        public void SetContent(string json)
        {
            this.Content = SerializationUtils<object>.FromJsonString(json);
        }

        public void AddAttachment(Attachment attachment)
        {
            if (Attachments == null) Attachments = new List<Attachment>();
            Attachments.Add(attachment);
        }

        public Transaction() { this.Import = new ImportReference(); this.Contact = new ContactReference(); }
    }
}
