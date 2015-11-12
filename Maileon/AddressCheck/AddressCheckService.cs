using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;

using System.Web;

using Maileon.Contacts;
using Maileon.Utils;

namespace Maileon.AddressCheck
{
    public class MaileonAddressCheckService : AbstractMaileonService
    {

        public static string SERVICE = "MAILEON ADDRESSCHECK";
        public static string ADDRESSCHECK_XML_MIME_TYPE = "application/xml";

        public MaileonAddressCheckService(MaileonConfiguration config) : base(config, SERVICE) { }

        public AddressQuality CheckAddressQuality(string email)
        {
            ResponseWrapper response = Get("2.0/address/quality/" + HttpUtility.UrlEncode(email), null, ADDRESSCHECK_XML_MIME_TYPE);
            return SerializationUtils<AddressQuality>.FromXmlString(response.Body);
        }
       
        public AddressQuality CheckAddressQuality(Contact contact)
        {
            return CheckAddressQuality(contact.Email);
        }

    }
}
