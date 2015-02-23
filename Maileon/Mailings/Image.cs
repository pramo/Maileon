using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    public class Image
    {
        [XmlElement("alt")]
        public string Alt;
        [XmlElement("height")]
        public int Height;
        [XmlElement("hosted")]
        public bool Hosted;
        [XmlElement("src")]
        public string Src;
        [XmlElement("title")]
        public string Title;
        [XmlElement("width")]
        public int Width;

        public Image() { }
    }
}
