using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Contacts
{
    /// <summary>
    /// A class representing an invalid contact
    /// </summary>
    public class InvalidContact : Contact
    {
        /// <summary>
        /// The SynchronizationError that makes this contact invalid
        /// </summary>
        [XmlElement("error")]
        public SynchronizationError Error { get; set; }

        public InvalidContact() { }
        public InvalidContact(SynchronizationError error) 
        {
		    this.Error = error;
	    }
    }
}
