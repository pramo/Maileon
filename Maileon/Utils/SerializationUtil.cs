using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

using System.Web.Script.Serialization;

using Maileon.Contacts;

using Maileon.Utils.JSON;

namespace Maileon.Utils
{
    internal static class SerializerFactory
    {
        private static Dictionary<Type, Dictionary<string, XmlSerializer>> _serializers = new Dictionary<Type, Dictionary<string, XmlSerializer>>();

        /// <summary>
        /// Returns the cached serializer for this type and root
        /// </summary>
        /// <param name="t">the type to deserialize</param>
        /// <param name="root">the name of the field to deserialize</param>
        /// <returns></returns>
        public static XmlSerializer GetSerializer(Type t, string root)
        {
            if(root == null) { root = string.Empty; }

            if (!_serializers.ContainsKey(t)) { _serializers.Add(t, new Dictionary<string, XmlSerializer>()); }
            if (_serializers[t].ContainsKey(root)) { return _serializers[t][root]; }

            XmlRootAttribute rootOverride = null;
            if (root != string.Empty) { rootOverride = new XmlRootAttribute { ElementName = root }; }

            XmlSerializer serializer = new XmlSerializer(t, rootOverride);

            _serializers[t].Add(root, serializer);
            return serializer;
        }
    }

    /// <summary>
    /// A static class for serializing/deserializing objects to/from XML/JSON strings
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal static class SerializationUtils<T>
    {
        /// <summary>
        /// Deserializes an XML string to an object
        /// </summary>
        /// <param name="src">the string to deserialize</param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static T FromXmlString(string src, string root)
        {
            T result = default(T);

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(src)))
            {
                result = (T)SerializerFactory.GetSerializer(typeof(T), root).Deserialize(stream);
            }

            return result;
        }

        /// <summary>
        /// Deserializes an XML string to an object
        /// </summary>
        /// <param name="src">the string to deserialize</param>
        /// <returns></returns>
        public static T FromXmlString(string src)
        {
            return FromXmlString(src, null);
        }

        /// <summary>
        /// Serializes an object to an XML string
        /// </summary>
        /// <param name="obj">the object to serialize</param>
        /// <param name="root"></param>
        /// <param name="omitXmlDeclaration"></param>
        /// <returns></returns>
        public static string ToXmlString(T obj, string root, bool omitXmlDeclaration)
        {
            string result = null;
            
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = omitXmlDeclaration;

            using(MemoryStream stream = new MemoryStream()) 
            {
                //disable namespace output
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    SerializerFactory.GetSerializer(typeof(T), root).Serialize(writer, obj, ns);
                }

                //after serializing we need to 'rewind' the stream to read it
                stream.Seek(0, SeekOrigin.Begin);
                using(StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }

        /// <summary>
        /// Serializes an object to an XML string
        /// </summary>
        /// <param name="obj">the object to serialize</param>
        /// <returns></returns>
        public static string ToXmlString(T obj)
        {
            return ToXmlString(obj, null, false);
        }

        /// <summary>
        /// Serializes an object to an XML string
        /// </summary>
        /// <param name="obj">the object to serialize</param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static string ToXmlString(T obj, string root)
        {
            return ToXmlString(obj, root, false);
        }

        /// <summary>
        /// Serializes an object to an XML string
        /// </summary>
        /// <param name="obj">the object to serialize</param>
        /// <param name="omitXmlDeclaration"></param>
        /// <returns></returns>
        public static string ToXmlString(T obj, bool omitXmlDeclaration)
        {
            return ToXmlString(obj, null, omitXmlDeclaration);
        }

        public static string ToJsonString(T obj)
        {
            string result = string.Empty;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new List<JavaScriptConverter>{new MaileonJsonConverter()});
            return serializer.Serialize(obj);
        }

        public static T FromJsonString(string src)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new List<JavaScriptConverter> { new MaileonJsonConverter() });
            return serializer.Deserialize<T>(src);
        }
    }
}
