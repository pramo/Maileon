using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maileon.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maileon.Transactions.Tests
{
    [TestClass()]
    public class MaileonTransactionsServiceTests
    {
        static MaileonConfiguration config = new MaileonConfiguration(
            MaileonTests.Properties.Settings.Default.apiKey,
            MaileonTests.Properties.Settings.Default.baseUri);

        static MaileonTransactionsService service = new MaileonTransactionsService(config);

        [TestMethod()]
        public void GetTransactionTypesCountTest()
        {
            int count = service.GetTransactionTypesCount();
            Assert.AreEqual(12, count);
        }

        [TestMethod()]
        public void GetTransactionTypesTest()
        {
            Page<TransactionType> types = service.GetTransactionTypes(1, 100);
            Assert.AreNotSame(0, types.TotalItems);

            TransactionType test = types.Items.Find(type => type.Name == "test_type");
            Attribute attrib = test.GetAttribute("customer.name");

            Assert.AreEqual(AttributeType.String, attrib.Type);
            Assert.IsTrue(attrib.Required);
        }

        [TestMethod()]
        public void CreateTransactionTypeTest()
        {
            AttributeType[] attributeTypes = new AttributeType[]
            {
                AttributeType.Boolean,
                AttributeType.Date,
                AttributeType.Double,
                AttributeType.Float,
                AttributeType.Integer,
                AttributeType.Json,
                AttributeType.String,
                AttributeType.Timestamp,
            };

            Random rnd = new Random();
            TransactionType type = new TransactionType("test_type_" + rnd.Next(10,99).ToString());

            foreach (AttributeType attributeType in attributeTypes)
            {
                type.Attributes.Add(new Attribute(attributeType, attributeType.ToString() + "_attribute", rnd.Next(0, 1) == 0));
            }

            long typeId = service.CreateTransactionType(type);
            Assert.IsNotNull(typeId);

            TransactionType newType = service.GetTransactionType(typeId);

            Assert.AreEqual(type.Name, newType.Name);
            Assert.AreEqual(type.Attributes.Count, newType.Attributes.Count);

            foreach (Attribute attribute in newType.Attributes)
            {
                Attribute expected = type.GetAttribute(attribute.Name);
                Assert.AreEqual(expected.Name, attribute.Name);
                Assert.AreEqual(expected.Required, attribute.Required);
                Assert.AreEqual(expected.Type, attribute.Type);
            }

            service.DeleteTransactionType(typeId);
        }

        [TestMethod()]
        public void DeleteTransactionTypeTest()
        {
            Random rnd = new Random();
            string name = "test_type_" + rnd.Next(10, 99).ToString();

            TransactionType type = new TransactionType(name);
            long id = service.CreateTransactionType(type);

            service.DeleteTransactionType(id);
            Page<TransactionType> page = service.GetTransactionTypes(1,100);

            Assert.IsNull(page.Items.Find(tr => tr.Name == name));
        }

        [TestMethod()]
        public void GetTransactionTypeTest()
        {
            TransactionType test = service.GetTransactionType(159L);
            Assert.AreEqual("test_type", test.Name);
            Assert.AreEqual(159L, test.Id);

            Attribute attrib = test.GetAttribute("customer.name");
            Assert.AreEqual(AttributeType.String, attrib.Type);
            Assert.IsTrue(attrib.Required);
        }

        [TestMethod()]
        public void FindTransactionTypeIdByNameTest()
        {
            long test = service.FindTransactionTypeIdByName("test_type");
            Assert.AreEqual(159L, test);
        }

        [TestMethod()]
        public void CreateTransactionsImportTest()
        {
            Dictionary<string, Contacts.Permission> testContacts = new Dictionary<string, Contacts.Permission>();
            testContacts.Add("coi@example.com", Contacts.Permission.ConfirmedOptIn);
            testContacts.Add("doi@example.com", Contacts.Permission.DoubleOptIn);
            testContacts.Add("doip@example.com", Contacts.Permission.DoubleOptInPlus);
            testContacts.Add("none@example.com", Contacts.Permission.None);
            testContacts.Add("other@example.com", Contacts.Permission.Other);
            testContacts.Add("soi@example.com", Contacts.Permission.SingleOptIn);

            Contacts.MaileonContactsService contactsService = new Contacts.MaileonContactsService(config);

            List<Transaction> transactions = new List<Transaction>();

            long testType = service.FindTransactionTypeIdByName("test_type");

            foreach (KeyValuePair<string,Contacts.Permission> elements in testContacts)
            {
                Transaction transaction = new Transaction();
                transaction.Import.Contact.Email = elements.Key;
                transaction.Import.Contact.Permission = elements.Value;
                transaction.Type = testType;
                transaction.SetContent("{ \"customer.name\":\"Balogh Viktor\", \"total\": 9.0 }");
                transactions.Add(transaction);
            }

            List<TransactionProcessingReport> reports = service.CreateTransactions(transactions);

            foreach (TransactionProcessingReport report in reports)
            {
                Assert.IsTrue(report.Queued);
            }

            foreach (KeyValuePair<string, Contacts.Permission> elements in testContacts)
            {
                List<Contacts.Contact> contacts = contactsService.GetContactsByEmail(elements.Key, null, null);
                Assert.AreNotEqual(0, contacts.Count);
                Assert.AreEqual(elements.Value, contacts.First().Permission);

                contactsService.DeleteContactsByEmail(elements.Key);
            }
        }


        [TestMethod()]
        public void CreateTransactionsTest()
        {
            List<Transaction> transactions = new List<Transaction>();
            long testType = service.FindTransactionTypeIdByName("test_type");
            string demoContent = "{ \"customer.name\":\"Balogh Viktor\", \"total\": 9.0 }";

            bool[] shouldBeQueued = new bool[] { true, false, true };

            Transaction existing = new Transaction();
            existing.Contact.Email = "balogh.viktor@maileon.hu";
            existing.Type = testType;
            existing.SetContent(demoContent);
            transactions.Add(existing);

            Transaction notExisting = new Transaction();
            notExisting.Contact.Email = "test@example.com";
            notExisting.Type = testType;
            notExisting.SetContent(demoContent);
            transactions.Add(notExisting);

            Transaction withAttachment = new Transaction();
            withAttachment.Contact.Email = "balogh.viktor@maileon.hu";
            withAttachment.Type = testType;
            withAttachment.SetContent(demoContent);
            withAttachment.AddAttachment(Attachment.FromFile("Resources\\maileon_transactions_overview.pdf"));
            transactions.Add(withAttachment);

            List<TransactionProcessingReport> reports = service.CreateTransactions(transactions, true, true);
            int i = 0;

            foreach (TransactionProcessingReport report in reports)
            {
                Assert.AreEqual(shouldBeQueued[i++], report.Queued);
            }
        }

        [TestMethod()]
        public void DeleteTransactionsTest()
        {
            long testType = service.FindTransactionTypeIdByName("test_type");
            service.DeleteTransactions(testType, new DateTime(2015, 10, 18));
        }

    }
}