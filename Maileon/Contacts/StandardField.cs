using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Maileon.Utils;

namespace Maileon.Contacts
{
    /// <summary>
    /// A class for wrapping standard fields
    /// </summary>
    public class StandardField 
    {
        /// <summary>
        /// The name of this standard field
        /// </summary>
        [XmlElement("name")]
        public StandardFieldName Name { get; set; }
        /// <summary>
        /// The value of this standard field
        /// </summary>
        [XmlElement("value")]
        public NullableValue<string> Value { get; set; }

        public StandardField(StandardFieldName name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public StandardField() { }
    }

    
}
