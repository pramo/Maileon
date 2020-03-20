using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maileon;
using Maileon.Contactfilters;

namespace MaileonTests
{
    [TestClass]
    public class MaileonContactFiltersServiceTests
    {
        protected MaileonContactFiltersService service;

        protected const string BASE_URI = "https://api.maileon.com/1.0";
        protected const string API_KEY = "260afd12-3b6a-40de-910c-b52102e280b1";
        protected const long EXISTING_CONTACT_FILTER_ID = 1755;

        public MaileonContactFiltersServiceTests()
        {
            service = new MaileonContactFiltersService(new MaileonConfiguration(API_KEY, BASE_URI, true));
        }

        [TestMethod]
        public void TestRefreshContactFilter()
        {
            service.RefreshContactFilterContacts(EXISTING_CONTACT_FILTER_ID);
        }
    }
}
