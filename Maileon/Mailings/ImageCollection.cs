using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    /// <summary>
    /// A class for wrapping a list of images
    /// </summary>
    [XmlRoot("images")]
    internal class ImageCollection
    {
        public ImageCollection() { Items = new List<Image>(); }
        public ImageCollection(List<Image> items) { Items = items; }

        [XmlElement("image")]
        public List<Image> Items { get; set; }

        public static implicit operator List<Image>(ImageCollection c)
        {
            return c.Items;
        }

        public static implicit operator ImageCollection(List<Image> c)
        {
            return new ImageCollection(c);
        }
    }
}
