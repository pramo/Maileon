using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Blacklists
{
    /// <summary>
    /// A class for representing a maileon blacklist
    /// </summary>
    [XmlRoot("blacklist")]
    public class Blacklist
    {
        /// <summary>
        /// The ID of this blacklist
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }
        /// <summary>
        /// The name of this blacklist
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
        /// <summary>
        /// The entries of this blacklist
        /// </summary>
        [XmlArray("entries"), XmlArrayItem("entry")]
        public List<string> Entries { get; set; }

        public Blacklist() { }
    }
}
