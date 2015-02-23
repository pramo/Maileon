using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils.Serialization.Contacts;

namespace Maileon.Contacts
{
    public enum StandardFields
    {
        ADDRESS,
        BIRTHDAY,
        CITY,
        COUNTRY,
        FIRSTNAME,
        GENDER,
        HNR,
        LASTNAME,
        FULLNAME,
        LOCALE,
        NAMEDAY,
        ORGANIZATION,
        REGION,
        SALUTATION,
        TITLE,
        ZIP,
    }

    public enum Permissions
    {
        None = 1,
        SingleOptIn = 2,
        ConfirmedOptIn = 3,
        DoubleOptIn = 4,
        DoubleOptInPlus = 5,
        Other = 6
    }

    public enum SynchronizationModes
    {
        Update = 1,
        Ignore = 2
    }

    public class Contact
    {
        public bool Anonymous { get; private set; }
        public string Id { get; private set; }

        public string ExternalId { get; private set; }
        public string Email { get; set; }
        public Permissions Permission { get; private set; }

        public Dictionary<string, object> CustomFields { get; set; }
        public Dictionary<StandardFields, object> StandardFields { get; set; }

        public Contact()
        {
            CustomFields = new Dictionary<string, object>();
            StandardFields = new Dictionary<StandardFields, object>();
        }

        public Contact(string email) : base()
        {
            this.Email = email;
        }

        internal Contact(XmlContact xml) : base()
        {
            this.Email = xml.Email;
            this.Anonymous = xml.Anonymous;
            this.ExternalId = xml.ExternalId;
            this.Permission = xml.Permission;
            this.Id = xml.Id;

            foreach(XmlCustomField field in xml.CustomFields)
            {
                this.CustomFields.Add(field.Name, field.Value);
            }

            foreach(XmlStandardField field in xml.StandardFields)
            {
                this.StandardFields.Add(field.Name, field.Value);
            }
        }
    }
}
