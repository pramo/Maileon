using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Xml.Serialization;

using Maileon.Contacts;
using Maileon.Reports;
using Maileon.Mailings;

namespace Maileon.Utils
{
    /// <summary>
    /// Helper class for converting enums to query parameters
    /// </summary>
    internal class MaileonEnums
    {
        /// <summary>
        /// Returns the XmlEnum value for an enum value
        /// </summary>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static string ToXmlString(Enum enumVal)
        {
            Type type = enumVal.GetType();
            MemberInfo[] memInfo = type.GetMember(enumVal.ToString());

            foreach (MemberInfo info in memInfo)
            {
                foreach (object attribute in info.GetCustomAttributes())
                {
                    XmlEnumAttribute xmlEnum = attribute as XmlEnumAttribute;

                    if (xmlEnum != null)
                    {
                        return xmlEnum.Name;
                    }
                }
            }
            return null;

        }

        /// <summary>
        /// Returns the XmlEnum value for an enum value
        /// </summary>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static T FromXmlString<T>(string val)
        {
            Type type = typeof(T);
            MemberInfo[] memInfo = type.GetMembers();

            foreach (MemberInfo info in memInfo)
            {
                foreach (object attribute in info.GetCustomAttributes())
                {
                    XmlEnumAttribute xmlEnum = attribute as XmlEnumAttribute;

                    if (xmlEnum != null && xmlEnum.Name == val)
                    {
                        return (T)Enum.Parse(type, info.Name);
                    }
                }
            }
            return default(T);
        }
    }
}
