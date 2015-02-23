using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils.Serialization.Contacts;

namespace Maileon.Contacts
{
    public class SynchronizationReport
    {
        /// <summary>
        /// Whether the synchronization was successful
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// The number of contacts in this synchronization
        /// </summary>
        public int CountContacts { get; private set; }

        /// <summary>
        /// The number of newly created contacts
        /// </summary>
        public int CountNewContacts { get; private set; }

        /// <summary>
        /// The number of already existing contacts
        /// </summary>
        public int CountExistingContacts { get; private set; }

        /// <summary>
        /// The number of invalid contacts
        /// </summary>
        public int CountInvalidContacts { get; private set; }

        /// <summary>
        /// The invalid contacts of this synchronization
        /// </summary>
        public List<InvalidContact> InvalidContacts { get; private set; }

        internal SynchronizationReport(XmlSynchronizationReport report)
        {
            this.Success = report.Success;
            this.CountContacts = report.CountContacts;
            this.CountExistingContacts = report.CountExistingContacts;
            this.CountInvalidContacts = report.CountInvalidContacts;
            this.CountNewContacts = report.CountNewContacts;
            
            this.InvalidContacts = new List<InvalidContact>();

            foreach(XmlInvalidContact contact in report.InvalidContacts)
            {
                this.InvalidContacts.Add(new InvalidContact(contact));
            }
        }

        public SynchronizationReport() { }
    }
}
