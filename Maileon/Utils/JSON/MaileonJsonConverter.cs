using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Web.Script.Serialization;

using Maileon.Transactions;

namespace Maileon.Utils.JSON
{
    /// <summary>
    /// A helper class that works in conjunction with MaileonJsonAttribute to enable property renaming in the serialized object
    /// </summary>
    internal class MaileonJsonConverter : JavaScriptConverter
    {
        /// <summary>
        /// The list of supported types
        /// </summary>
        private static List<Type> _supportedTypes = null;

        public override IEnumerable<Type> SupportedTypes
        {
            get 
            {
                if (_supportedTypes == null) _supportedTypes = GetSupportedTypes();

                return _supportedTypes;
            }
        }

        /// <summary>
        /// Looks for types in the current assembly that have the MaileonJsonAttribute custom attribute set for a public property
        /// </summary>
        /// <returns></returns>
        private static List<Type> GetSupportedTypes()
        {
            List<Type> result = new List<Type>();

            bool found = false;

            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                found = false;
                PropertyInfo[] props = type.GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    object[] attrs = prop.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        MaileonJsonAttribute customNameProperty = attr as MaileonJsonAttribute;
                        if (customNameProperty != null)
                        {
                            result.Add(type);
                            found = true;
                        }
                        if (found) break;
                    }
                    if (found) break;
                }
            }

            return result;
        }

        /// <summary>
        /// Deserilaizes an object that has a MaileonJsonAttribute
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="type"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            object result = Activator.CreateInstance(type);

            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    MaileonJsonAttribute customNameProperty = attr as MaileonJsonAttribute;
                    if (customNameProperty != null)
                    {
                        string propName = prop.Name;
                        string customName = customNameProperty.Name;

                        if (dictionary.ContainsKey(customName))
                        {
                            prop.SetValue(result, serializer.ConvertToType(dictionary[customName], prop.PropertyType));
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Serializes an object that has a MaileonJsonAttribute
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            Dictionary<string,  object> dictionary = new Dictionary<string, object>();

            PropertyInfo[] props = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    MaileonJsonAttribute customNameProperty = attr as MaileonJsonAttribute;
                    if (customNameProperty != null && prop.GetValue(obj) != null)
                    {
                        string propName = prop.Name;
                        string customName = customNameProperty.Name;

                        dictionary.Add(customName, prop.GetValue(obj));
                    }
                }
            }

            return dictionary;
        }
    }
}
