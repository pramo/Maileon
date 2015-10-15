using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class for wrapping a list of bounces
    /// </summary>
    [XmlRoot("blocks")]
    internal class BlockCollection
    {
        public BlockCollection() { Items = new List<Block>(); }
        public BlockCollection(List<Block> items) { Items = items; }

        [XmlElement("block")]
        public List<Block> Items { get; set; }

        public static implicit operator List<Block>(BlockCollection c)
        {
            return c.Items;
        }

        public static implicit operator BlockCollection(List<Block> c)
        {
            return new BlockCollection(c);
        }
    }
}
