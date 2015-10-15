using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace Maileon
{
    interface IMaileonXmlSerializable<T>
    {
        T ReadXml(XmlReader reader);
        void WriteXml(XmlWriter writer, T obj);
    }
}
