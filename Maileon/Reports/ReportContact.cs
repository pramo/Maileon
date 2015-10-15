using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Contacts;
using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A contact used in Maileon reports
    /// </summary>
    public class ReportContact : Contact
    {
        /// <summary>
        /// Whether this contact is anonymized
        /// </summary>
        [XmlAttribute("anonymous")]
        public new bool Anonymous { get; set; }

        /// <summary>
        /// The field backups for this contact
        /// </summary>
        [XmlArray("field_backups"), XmlArrayItem("field_backup")]	
	    public List<FieldBackupInstruction> FieldBackups { get; set; }

        public ReportContact() { }
    }
}
