using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maileon.Contacts
{
    /// <summary>
    /// Maileon Contact standard fields
    /// </summary>
    public enum StandardFieldName
    {
        /// <summary>
        /// The length must not exceed 255 characters.
        /// </summary>
        [XmlEnum("ADDRESS")]
        Address,
        /// <summary>
        /// Allowed patterns: yyyy-mm-dd and yyyy-mm-dd hh:mm:ss
        /// </summary>
        [XmlEnum("BIRTHDAY")]
        Birthday,
        /// <summary>
        /// The length must not exceed 255 characters.
        /// </summary>
        [XmlEnum("CITY")]
        City,
        /// <summary>
        /// The length must not exceed 255 characters.
        /// </summary>
        [XmlEnum("COUNTRY")]
        Country,
        /// <summary>
        /// The length must not exceed 255 characters.
        /// </summary>
        [XmlEnum("FIRSTNAME")]
        Firstname,
        /// <summary>
        /// Allowed values: m (male) and f (female)
        /// </summary>
        [XmlEnum("GENDER")]
        Gender,
        /// <summary>
        /// The length must not exceed 255 characters.
        /// </summary>
        [XmlEnum("HNR")]
        HNR,
        /// <summary>
        /// The length must not exceed 255 characters.
        /// </summary>
        [XmlEnum("LASTNAME")]
        Lastname,
        /// <summary>
        /// The length must not exceed 255 characters.
        /// </summary>
        [XmlEnum("FULLNAME")]
        Fullname,
        /// <summary>
        /// The value must follow the pattern: xx_XX (example: de_DE) or xx (example: en)
        /// </summary>
        [XmlEnum("LOCALE")]
        Locale,
        /// <summary>
        /// Allowed patterns: yyyy-mm-dd and yyyy-mm-dd hh:mm:ss
        /// </summary>
        [XmlEnum("NAMEDAY")]
        Nameday,
        /// <summary>
        /// The length must not exceed 255 characters.
        /// </summary>
        [XmlEnum("ORGANIZATION")]
        Organization,
        /// <summary>
        /// The length must not exceed 255 characters.
        /// </summary>
        [XmlEnum("REGION")]
        Region,
        /// <summary>
        /// The length must not exceed 255 characters.
        /// </summary>
        [XmlEnum("SALUTATION")]
        Salutation,
        /// <summary>
        /// The length must not exceed 255 characters.
        /// </summary>
        [XmlEnum("TITLE")]
        Title,
        /// <summary>
        /// The length must not exceed 255 characters.
        /// </summary>
        [XmlEnum("ZIP")]
        ZIP
    }
}
