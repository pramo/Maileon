using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Contacts
{
    /// <summary>
    /// A class for wrapping a list of contacts
    /// </summary>
    [XmlRoot("backup_instructions")]
    internal class FieldBackupInstructionCollection
    {
        public FieldBackupInstructionCollection() { Items = new List<FieldBackupInstruction>(); }
        public FieldBackupInstructionCollection(List<FieldBackupInstruction> items) { Items = items; }

        [XmlElement("backup_instruction")]
        public List<FieldBackupInstruction> Items { get; set; }

        public static implicit operator List<FieldBackupInstruction>(FieldBackupInstructionCollection c)
        {
            return c.Items;
        }

        public static implicit operator FieldBackupInstructionCollection(List<FieldBackupInstruction> c)
        {
            return new FieldBackupInstructionCollection(c);
        }
    }
}
