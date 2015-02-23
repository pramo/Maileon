using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using Maileon.Utils.JSON;

namespace Maileon.Transactions
{
    /// <summary>
    /// A class for wrapping Maileon JSON contact references
    /// </summary>
    public class ContactReference
    {
        /// <summary>
        /// The id of this contact
        /// </summary>
        [MaileonJsonAttribute("id")]
        public int? Id { get; set; }

        /// <summary>
        /// The external id of the contact
        /// </summary>
        [MaileonJsonAttribute("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// The email address of the contact
        /// </summary>
        [MaileonJsonAttribute("email")]
        public string Email { get; set; }

        public ContactReference(int? id, string externalId, string email)
        {
            this.Id = id;
            this.ExternalId = externalId;
            this.Email = email;
        }

        public ContactReference(string email)
        {
            this.Email = email;
        }

        public ContactReference() { }
    }
}
