using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Maileon;
using Maileon.Contacts;

namespace MaileonUnitTests
{
    [TestClass]
    public class MaileonContactsServiceTests
    {
        static MaileonConfiguration config = new MaileonConfiguration("5896e6bf-752b-4db3-955e-c24fc0479bd1", "https://api.maileon.com/1.0/");
        MaileonContactsService service = new MaileonContactsService(config);

        [TestMethod]
        public void CreateContact_Test()
        {
            Random random = new Random((int)DateTime.Now.Ticks);

            string email = RandomString(random, 4) + "@" + RandomString(random, 4) + ".hu";

            Dictionary<XmlStandardFieldNames,string> standardFields = new Dictionary<XmlStandardFieldNames,string>();
            Dictionary<string,string> customFields = new Dictionary<string,string>();

            Array values = Enum.GetValues(typeof(XmlPermissions));
            XmlPermissions permission = (XmlPermissions)values.GetValue(random.Next(values.Length));

            XmlContact contact = new XmlContact(email);
            contact.Permission = permission;

            foreach(var key in Enum.GetValues(typeof(XmlStandardFieldNames)))
            {
                string value = RandomString(random, 5);

                standardFields.Add((XmlStandardFieldNames)key, value);
                contact.StandardFields.Add(new XmlStandardField((XmlStandardFieldNames)key, value));
            }

            service.CreateContact(contact, XmlSynchronizationMode.Update);

            List<XmlContact> contacts = service.GetContactsByEmail(email, new List<XmlStandardFieldNames>(standardFields.Keys), null);

            XmlContact newContact = contacts[0];

            Assert.AreEqual(newContact.Email, email, "Email address not updated correctly");
            Assert.AreEqual(newContact.Permission, permission, "Permission not updated correctly");

            //TODO...
        }

        private string RandomString(Random random, int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
