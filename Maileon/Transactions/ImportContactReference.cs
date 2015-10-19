using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Contacts;
using Maileon.Utils.JSON;

namespace Maileon.Transactions
{
    public class ImportContactReference : IMaileonJsonSerializable
    {
        /// <summary>
        /// The id of this contact
        /// </summary>
        [MaileonJson("id")]
        public int? Id { get; set; }

        /// <summary>
        /// The external id of the contact
        /// </summary>
        [MaileonJson("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// The email address of the contact
        /// </summary>
        [MaileonJson("email")]
        public string Email { get; set; }

        /// <summary>
        /// The permission of the contact
        /// </summary>
        [MaileonJson("permission")]
        public Permission Permission { get; set; }

        public ImportContactReference(string email, Permission permission)
        {
            this.Permission = permission;
            this.Email = email;
        }

        public ImportContactReference(string email)
        {
            this.Permission = Permission.None;
        }

        public bool IsEmpty()
        {
            return Email == null && Id == null && ExternalId == null;
        }

        public ImportContactReference() { }
    }
}
