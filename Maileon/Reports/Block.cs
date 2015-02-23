using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class representing a block status change
    /// </summary>
    [XmlRoot("block")]
    public class Block : AbstractEvent
    {
        /// <summary>
        /// The old block status
        /// </summary>
        [XmlElement("old_status")]
        public BlockStatus OldStatus { get; set; }
        /// <summary>
        /// The new block status
        /// </summary>
        [XmlElement("new_status")]
        public BlockStatus NewStatus { get; set; }
        /// <summary>
        /// The reason for the status change
        /// </summary>
        [XmlElement("reason")]
        public BlockReason Reason { get; set; }

        public Block() : base() { }
    }
}
