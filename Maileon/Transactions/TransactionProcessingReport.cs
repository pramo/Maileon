using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils.JSON;

using System.Runtime.Serialization;

namespace Maileon.Transactions
{
    /// <summary>
    /// A class for wrapping Maileon JSON transaction processing reports
    /// </summary>
    public class TransactionProcessingReport
    {
        /// <summary>
        /// The contact identification
        /// </summary>
        [MaileonJsonAttribute("contact")]
        public ContactReference Contact { get; set; }
        /// <summary>
        /// Whether the transaction is succesfully queued
        /// </summary>
        [MaileonJsonAttribute("queued")]
        public bool Queued { get; set; }
        /// <summary>
        /// The message of this report
        /// </summary>
        [MaileonJsonAttribute("message")]
        public string Message { get; set; }

        public TransactionProcessingReport() { }
    }
}
