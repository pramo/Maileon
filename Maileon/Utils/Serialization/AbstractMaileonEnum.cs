using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Maileon.Contacts;

namespace Maileon.Utils.Serialization
{
    /// <summary>
    /// Maileon Contact permissions
    /// </summary>
    public class AbstractMaileonEnum<T>
    {
        [XmlText]
        public string Value{ get; set; }

        [XmlIgnore]
        private T EnumValue 
        {
            get { return _permission; }
            set 
            { 

                _permission = value; 
            }
        }
        private T _permission;

        protected abstract static string GetStringValue(T enumValue);
       

        public AbstractMaileonEnum() 
        {
            EnumValue = default(T);
        }

        public AbstractMaileonEnum(T enumValue)
        {
            this.EnumValue = enumValue;
        }

        public static implicit operator T(AbstractMaileonEnum<T> enumValue)
        {
            return enumValue.EnumValue;
        }

        public static implicit operator AbstractMaileonEnum<T>(T enumValue)
        {
            return new AbstractMaileonEnum<T>(enumValue);
        }
    }
}
