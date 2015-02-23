using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Utils.Serialization.Contacts
{
    /// <summary>
    /// A class for wrapping a list of contacts
    /// </summary>
    [XmlRoot("backup_instructions")]
    internal class XmlFieldBackupInstructionCollection
    {
        public XmlFieldBackupInstructionCollection() { Items = new List<XmlFieldBackupInstruction>(); }
        public XmlFieldBackupInstructionCollection(List<XmlFieldBackupInstruction> items) { Items = items; }

        [XmlElement("backup_instruction")]
        public List<XmlFieldBackupInstruction> Items { get; set; }

        public static implicit operator List<XmlFieldBackupInstruction>(XmlFieldBackupInstructionCollection c)
        {
            return c.Items;
        }

        public static implicit operator XmlFieldBackupInstructionCollection(List<XmlFieldBackupInstruction> c)
        {
            return new XmlFieldBackupInstructionCollection(c);
        }
    }
}
