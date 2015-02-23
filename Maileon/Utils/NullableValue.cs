using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Maileon.Utils
{
    /// <summary>
    /// Helper class for serializing Maileon API compatible nullable types
    /// </summary>
    /// <typeparam name="T">determines what type this should encapsulate</typeparam>
    public class NullableValue<T> : IXmlSerializable
    {
        /// <summary>
        /// The actual value of this element
        /// </summary>
        public T Value 
        {
            get { return _value; }

            set { _value = value; HasValue = value != null; }
        }
        private T _value;
        public bool HasValue { get; set; }

        public NullableValue() { this.HasValue = false; }
        public NullableValue(T t)
        {
            this.HasValue = true;
            this.Value = t;
        }

        public static implicit operator T(NullableValue<T> t)
        {
            return (T)t.Value;
        }

        public static implicit operator NullableValue<T>(T t)
        {
            return new NullableValue<T>(t);
        }

        public override string ToString()
        {
            if(!HasValue)
            {
                return "null";
            }
            else
            { 
                return Value.ToString();
            }
        }

        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            HasValue = !reader.IsEmptyElement;
            reader.ReadStartElement();
            if (HasValue)
            {
                Value = (T)reader.ReadContentAs(typeof(T), null);
                reader.ReadEndElement();
            }
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            if(!HasValue)
            { 
                writer.WriteAttributeString("nil", "true");
            }
            else
            {
                //TODO: may not be possbile, but try to find a better way of dealing with this
                if (typeof(T) != typeof(string) && !typeof(T).IsPrimitive) throw new ArgumentException("NullableValue cannot be used to serialize complex types");
                
                writer.WriteString(Value.ToString());
            }
        }
    }
}
