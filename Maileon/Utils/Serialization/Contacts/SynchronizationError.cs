using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Utils.Serialization.Contacts
{
    public class XmlSynchronizationError
    {
        /// <summary>
        /// This private variable stores the valid errorcodes and their names/descriptions
        /// </summary>
        private static string[][] _errorData = new string[][]{
            new string[]{"missing external id", "The parameter use_external_id was true and the contact has no value for the external_id."},
            new string[]{"missing email", "The email address is required when use_external_id is set to false or when the contact is new."},
            new string[]{"invalid email", "The syntax of the email address is not correct."},
            new string[]{"duplicate external id", "The value of external_id already exists for another contact, either in the provided list or under the persisted contacts."},
            new string[]{"duplicate email", "The value of the email address already exists for another contact, either in the provided list or under the persisted contacts."},
            new string[]{"illegal standard field value: address", "The length must not exceed 255 characters."},
            new string[]{"illegal standard field value: city", "The length must not exceed 255 characters."},
            new string[]{"illegal standard field value: firstname", "The length must not exceed 255 characters."},
            new string[]{"illegal standard field value: fullname", "The length must not exceed 255 characters."},
            new string[]{"illegal standard field value: hnr", "The length must not exceed 255 characters."},
            new string[]{"illegal standard field value: lastname", "The length must not exceed 255 characters."},
            new string[]{"illegal standard field value: organization", "The length must not exceed 255 characters."},
            new string[]{"illegal standard field value: region", "The length must not exceed 255 characters."},
            new string[]{"illegal standard field value: state", "The length must not exceed 255 characters."},
            new string[]{"illegal standard field value: title", "The length must not exceed 255 characters."},
            new string[]{"illegal standard field value: zip", "The length must not exceed 255 characters."},
            new string[]{"illegal standard field value: birthday", "Allowed patterns: yyyy-mm-dd and yyyy-mm-dd hh:mm:ss"},
            new string[]{"illegal standard field value: nameday", "Allowed patterns: yyyy-mm-dd and yyyy-mm-dd hh:mm:ss"},
            new string[]{"illegal standard field value: gender", "Allowed values: m (male) and f (female)"},
            new string[]{"illegal standard field value: locale", "The value must follow the pattern: xx_XX (example: de_DE)"},
            new string[]{"no such custom field", "The name of the custom field is not declared in the account."},
            new string[]{"illegal custom field boolean value", "Allowed values: 0, 1, true and false"},
            new string[]{"illegal custom field float value", ""},
            new string[]{"illegal custom field double value", ""},
            new string[]{"illegal custom field integer value", ""},
            new string[]{"illegal custom field string value", "The length must not exceed 255 characters."},
            new string[]{"illegal custom field timestamp value", "Allowed patterns: yyyy-mm-dd and yyyy-mm-dd hh:mm:ss"}
        };

        /// <summary>
        /// The error code of this SynchronizationError
        /// </summary>
        [XmlAttribute("code")]
        public int Value { get; set; }

        /// <summary>
        /// The field which has the error
        /// </summary>
        [XmlElement("error_field")]
        public string Field { get; set; }

        /// <summary>
        /// The message of this error
        /// </summary>
        [XmlIgnore]
        public string Message 
        { 
            get 
            {
                if (Value < 1 || Value > _errorData.Length) return string.Empty;
                return _errorData[Value - 1][0]; 
            }
            private set { } 
        }

        /// <summary>
        /// The description of this erorr
        /// </summary>
        [XmlIgnore]
        public string Description 
        { 
            get 
            { 
                if(Value < 1 || Value > _errorData.Length) return string.Empty;
                return _errorData[Value - 1][1]; 
            }
            private set { }
        }

        public XmlSynchronizationError() { }
    }
}
