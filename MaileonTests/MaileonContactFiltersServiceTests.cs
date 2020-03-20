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

        public MaileonContactFiltersServiceTests()
        {
            service = new MaileonContactFiltersService(new MaileonConfiguration(Properties.Settings.Default.API_KEY, Properties.Settings.Default.BASE_URI, true));
        }

        [TestMethod]
        public void TestRefreshContactFilter()
        {
            service.RefreshContactFilterContacts(Properties.Settings.Default.EXISTING_CONTACT_FILTER_ID);
        }
    }
}
