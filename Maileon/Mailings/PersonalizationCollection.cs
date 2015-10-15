using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Mailings
{
    /// <summary>
    /// A class for wrapping a list of personalizations
    /// </summary>
    [XmlRoot("personalizations")]
    public class PersonalizationCollection
    {
        public PersonalizationCollection() { Items = new List<Personalization>(); }
        public PersonalizationCollection(List<Personalization> items) { Items = items; }

        [XmlElement("personalization")]
        public List<Personalization> Items { get; set; }

        public static implicit operator List<Personalization>(PersonalizationCollection c)
        {
            return c.Items;
        }

        public static implicit operator PersonalizationCollection(List<Personalization> c)
        {
            return new PersonalizationCollection(c);
        }
    }
}
