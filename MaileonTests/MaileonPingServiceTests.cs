using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maileon;
using Maileon.Ping;

namespace MaileonTests
{
    [TestClass]
    public class MaileonPingServiceTests
    {
        [TestMethod]
        public void TestBaseUriEndingInSlash()
        {
            MaileonPingService service = new MaileonPingService(new MaileonConfiguration(Properties.Settings.Default.API_KEY, Properties.Settings.Default.BASE_URI_SLASH, true));
            service.CheckGet();
        }

        [TestMethod]
        public void TestBaseUriWithouthSlash()
        {
            MaileonPingService service = new MaileonPingService(new MaileonConfiguration(Properties.Settings.Default.API_KEY, Properties.Settings.Default.BASE_URI, true));
            service.CheckGet();
        }
    }
}
