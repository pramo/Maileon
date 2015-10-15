using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Blacklists
{
    /// <summary>
    /// A class representing a named import of entries to import to a blacklist
    /// </summary>
    [XmlRoot("add_entries_action")]
    public class EntryCollection
    {
        /// <summary>
        /// The name of this entry collection
        /// </summary>
        [XmlElement("import_name")]
        public string Name { get; set; }
        /// <summary>
        /// The items of this entry
        /// </summary>
        [XmlArray("entries"), XmlArrayItem("entry")]
        public List<string> Items { get; set; }

        public EntryCollection() { this.Items = new List<string>(); }
        public EntryCollection(string name, List<string> entries)
        {
            this.Name = name;
            this.Items = entries;
        }
    }
}
