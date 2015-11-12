using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maileon.AddressCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maileon.AddressCheck.Tests
{
    [TestClass()]
    public class MaileonAddressCheckServiceTests
    {
        private MaileonAddressCheckService service;

        public MaileonAddressCheckServiceTests()
        {
            service = new MaileonAddressCheckService(new MaileonConfiguration("wiera:KAtAQQxMPP", "https://adc.maileon.com/svc/"));
        }

        [TestMethod()]
        public void CheckAddressQualityTest()
        {
            AddressQuality exists = service.CheckAddressQuality("balogh.viktor@maileon.hu");
            Assert.AreEqual(exists.Syntax, Syntax.Valid);
            Assert.IsTrue(exists.DomainExists);
            Assert.IsTrue(exists.MailserverExists);
            Assert.IsTrue(exists.NoAddressError);
            Assert.AreEqual(exists.Address, AddressExistance.Exists);
            Assert.AreEqual(exists.MailserverDiagnosis, MailserverDiagnosis.Truthful);

            AddressQuality not_exists = service.CheckAddressQuality("balogh.viktorka@maileon.hu");
            Assert.AreEqual(not_exists.Address, AddressExistance.NonExtistant);
            Assert.IsTrue(exists.DomainExists);

            AddressQuality not_exists_domain = service.CheckAddressQuality("balogh.viktorka@gmale.com");
            Assert.AreEqual(not_exists_domain.Syntax, Syntax.Valid);
            Assert.AreNotEqual(not_exists_domain.DomainScores.Items.Count, 0);
            Assert.AreEqual(not_exists_domain.DomainScores.Items.First().Domain, "gmail.com");
            Assert.IsFalse(not_exists_domain.MailserverExists);

            AddressQuality not_exists_invalid = service.CheckAddressQuality("balogh@viktorka@gmale");
            Assert.AreEqual(not_exists_invalid.Syntax, Syntax.Invalid);

            AddressQuality decoded = service.CheckAddressQuality("balogh.viktör@gmail.com");
            Assert.AreEqual(decoded.Syntax, Syntax.Decoded);
            Assert.AreNotEqual(decoded.DecodedAddress.Length, 0);
        }
    }
}