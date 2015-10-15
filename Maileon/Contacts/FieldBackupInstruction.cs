using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Contacts
{
    [XmlRoot("backup_instruction")]
    public class FieldBackupInstruction 
    {
        /// <summary>
        /// The ID of a contact field backup instruction. This can be used e.g. to delete the instruction.
        /// </summary>
        [XmlElement("id")]
	    public long Id { get; set; }

        /// <summary>
        /// Defines if the field is a standard contact field, a custom contact field, or the field of a contact event.
        /// </summary>
        [XmlElement("type")]
	    public FieldType Type;

        /// <summary>
        /// Only required when type = “event”. In this case this contains the attribute type.
        /// </summary>
        [XmlElement("subtype")]
	    public string Subtype;

        /// <summary>
        /// The name of the standard/custom contact field to save. In case of type “event” this is the name of the event type.
        /// </summary>
        [XmlElement("name")]
	    public string Name;

        public FieldBackupInstruction() { }
        public FieldBackupInstruction(string name) : this(name, FieldType.Custom, null) { }
        public FieldBackupInstruction(StandardFieldName name) : this(Enum.GetName(typeof(StandardFieldName), name).ToUpper(), FieldType.Standard, null) { }
        public FieldBackupInstruction(string name, string subType) : this(name, FieldType.Event, subType) { }
        private FieldBackupInstruction(string name, FieldType type) : this(name, type, null) { }
        private FieldBackupInstruction(string name, FieldType type, string subType)
        {
            this.Name = name;
            this.Type = type;
            this.Subtype = subType;
        }
    }
}
