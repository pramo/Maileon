using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils.Serialization.Contacts;

namespace Maileon.Contacts
{
    public class InvalidContact : Contact
    {
        /// <summary>
        /// The SynchronizationError that makes this contact invalid
        /// </summary>
        public SynchronizationError Error { get; private set; }

        public InvalidContact(XmlInvalidContact contact) : base((XmlContact)contact)
        {
            this.Error = new SynchronizationError(contact.Error);
        }
    }
}
