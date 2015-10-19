using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Contacts;
using Maileon.Utils.JSON;

namespace Maileon.Transactions
{
    public class ImportReference : IMaileonJsonSerializable
    {
        [MaileonJson("contact")]
        public ImportContactReference Contact { get; set; }

        public bool IsEmpty()
        {
            return Contact.IsEmpty();
        }

        public ImportReference(ImportContactReference cr)
        {
            this.Contact = cr;
        }

        public ImportReference() { this.Contact = new ImportContactReference(); }

        public static implicit operator ImportReference(ImportContactReference cr)
        {
            return new ImportReference(cr);
        }
    }
}
