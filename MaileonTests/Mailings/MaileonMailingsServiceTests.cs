using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maileon.Mailings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils;

using System.IO;

namespace Maileon.Mailings.Tests
{
    [TestClass()]
    public class MaileonMailingsServiceTests
    {
        static MaileonConfiguration config = new MaileonConfiguration(
            MaileonTests.Properties.Settings.Default.apiKey,
            MaileonTests.Properties.Settings.Default.baseUri);

        static MaileonMailingsService service = new MaileonMailingsService(config);

        private static string GenerateUniqueName(string prefix)
        {
            return string.Format("{0}_{1}", prefix, Guid.NewGuid());
        }

        private static DateTime GetRandomPastDateTimeAfter(DateTime start)
        {
            Random gen = new Random();

            int range = (DateTime.Today - start).Days - 1;

            start = start.AddDays(gen.Next(range));
            start = start.AddMilliseconds(24 * 60 * 60 * 1000);

            return start;
        }

        private long GetRandomMailingIdByType(MailingType type)
        {
            Page<Mailing> page = service.GetMailingsByTypes(new List<MailingType>() { type }, null, null, null, 1, 1);
            Assert.AreNotSame(0, page.TotalItems);

            return page.Items.First().Id;
        }

        private long GetRandomMailingIdByState(MailingState state)
        {
            Page<Mailing> page = service.GetMailingsByStates(new List<MailingState>() { state }, null, null, null, 1, 1);
            Assert.AreNotSame(0, page.TotalItems);

            return page.Items.First().Id;
        }

        [TestMethod()]
        public void CreateDeleteMailingTest()
        {
            //FIXME: GetMailingsBySubject doesn't work at all
            Assert.Inconclusive();

            string name = GenerateUniqueName("testname");
            string subject = GenerateUniqueName("subject");

            foreach (MailingType type in allTypes)
            {
                long id = service.CreateMailing(name, subject, type);
                Assert.IsNotNull(id);
                
                Page<Mailing> page = service.GetMailingsBySubject(subject, StringOperation.Equals, allFields, null, null, 1, 1);
                Assert.AreNotEqual(0, page.TotalItems);

                Mailing m = page.Items.First();
                Assert.IsTrue( (string)m.GetField(FieldType.Name) == name && m.Id == id );

                service.DeleteMailing(id);

                page = service.GetMailingsBySubject(subject, StringOperation.Equals, allFields, null, null, 1, 1);
                Assert.AreEqual(0, page.TotalItems);
            }
        }

        [TestMethod()]
        public void SendMailingNowTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetArchiveUrlTest()
        {
            string url = service.GetArchiveUrl(MaileonTests.Properties.Settings.Default.mailingIdExistingRegular);

            Assert.AreEqual("http://sandbox.maileon.com/u/archive/z6SQtk30DaM", url);
        }

        [TestMethod()]
        public void GetTypeTest()
        {
            Page<Mailing> page = service.GetMailingsByTypes(allTypes, allFields, null, null, 1, 1000);

            HashSet<MailingType> seenTypes = new HashSet<MailingType>();

            foreach (Mailing m in page.Items)
            {
                foreach (MailingType type in allTypes)
                {
                    if ((MailingType)m.GetField(FieldType.Type) == type)
                    {
                        seenTypes.Add(type);
                        Assert.AreEqual(type, service.GetType(m.Id));
                    }
                }

            }

            Assert.AreEqual(allTypes.Count, seenTypes.Count);
        }

        [TestMethod()]
        public void GetStateTest()
        {
            Page<Mailing> page = service.GetMailingsByStates(allStates, allFields, null, null, 1, 1000);

            foreach(Mailing m in page.Items)
            {
                Assert.AreEqual((MailingState)m.GetField(FieldType.State), service.GetState(m.Id));
            }
        }

        [TestMethod()]
        public void IsSealedTest()
        {
            // A done mailing is always sealed
            bool shouldBeSealed = service.IsSealed(GetRandomMailingIdByState(MailingState.Done));
            Assert.IsTrue(shouldBeSealed);

            // A draft mailing is never sealed
            bool shouldNotBeSealed = service.IsSealed(GetRandomMailingIdByState(MailingState.Draft));
            Assert.IsFalse(shouldNotBeSealed);
        }

        [TestMethod()]
        public void GetNameTest()
        {
            string name = service.GetName(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual("regularMailingTest", name);
        }

        [TestMethod()]
        public void GetAuthorTest()
        {
            string author = service.GetAuthor(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual("balogh.viktor@maileon.hu", author);
        }

        [TestMethod()]
        public void GetTargetGroupIdTest()
        {
            long id = service.GetTargetGroupId(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual(584, id);
        }

        [TestMethod()]
        public void GetArchivalDurationTest()
        {
            int duration = service.GetArchivalDuration(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual(12, duration);
        }

        [TestMethod()]
        public void GetTrackingDurationTest()
        {
            int duration = service.GetTrackingDuration(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual(2, duration);
        }

        [TestMethod()]
        public void GetMaxAttachmentSizeTest()
        {
            int size = service.GetMaxAttachmentSize(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual(500, size);
        }

        [TestMethod()]
        public void GetMaxContentSizeTest()
        {
            int size = service.GetMaxContentSize(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual(100, size);
        }

        [TestMethod()]
        public void GetSetSpeedLevelTest()
        {
            SpeedLevel[] speedLevels = new SpeedLevel[]
            {
                SpeedLevel.High,
                SpeedLevel.Low,
                SpeedLevel.Medium,
                SpeedLevel.Supersonic
            };

            long draft = GetRandomMailingIdByState(MailingState.Draft);
            SpeedLevel originalSpeed = service.GetSpeedLevel(draft);

            foreach(SpeedLevel speed in speedLevels)
            {
                service.SetSpeedLevel(draft, speed);
                SpeedLevel newSpeed = service.GetSpeedLevel(draft);

                Assert.AreEqual(speed, newSpeed);

            }
            
            service.SetSpeedLevel(draft, originalSpeed);
            SpeedLevel restoredSpeed = service.GetSpeedLevel(draft);

            Assert.AreEqual(originalSpeed, restoredSpeed);
        }

        [TestMethod()]
        public void GetSetTrackingStrategyTest()
        {
            TrackingStrategy[] strategies = new TrackingStrategy[]
            {
                TrackingStrategy.Anonymous,
                TrackingStrategy.HighestPermission,
                TrackingStrategy.None,
                TrackingStrategy.SingleRecipient
            };

            long draft = GetRandomMailingIdByState(MailingState.Draft);
            TrackingStrategy originalStragegy = service.GetTrackingStrategy(draft);

            foreach (TrackingStrategy strategy in strategies)
            {
                service.SetTrackingStrategy(draft, strategy);
                TrackingStrategy newStrategy = service.GetTrackingStrategy(draft);

                Assert.AreEqual(strategy, newStrategy);
            }

            service.SetTrackingStrategy(draft, originalStragegy);
            TrackingStrategy restoredStrategy = service.GetTrackingStrategy(draft);

            Assert.AreEqual(originalStragegy, restoredStrategy);
        }
        

        [TestMethod()]
        public void GetCountDOIConfirmationLinksTest()
        {
            long draft = GetRandomMailingIdByType(MailingType.Doi);

            int count = service.GetCountDOIConfirmationLinks(draft, MailingFormat.HTML);
            Assert.Fail();

        }

        [TestMethod()]
        public void GetCountOnlineVersionLinksTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCountUnsubscribeLinksTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetSubjectTest()
        {
            string subject = service.GetSubject(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual(subject, "Regular mailing subject line with utf8 characters: öüóőúéáűíÖÜÓŐÚÉÁŰÍ - [[CONTACT|EMAIL|fallback]]");
        }

        [TestMethod()]
        public void GetSenderAliasTest()
        {
            string alias = service.GetSenderAlias(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual("Sender Alias: öüóőúéáűíÖÜÓŐÚÉÁŰÍ", alias);
        }

        [TestMethod()]
        public void GetSenderAddressTest()
        {
            string email = service.GetSenderAddress(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual("localpart@sandbox.maileon.com", email);
        }

        [TestMethod()]
        public void GetRecipientAliasTest()
        {
            string alias = service.GetRecipientAlias(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual("Recipient Alias: öüóőúéáűíÖÜÓŐÚÉÁŰÍ", alias);
        }

        [TestMethod()]
        public void GetHtmlContentSizeTest()
        {
            long size = service.GetHtmlContentSize(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual(45122L, size);
        }

        [TestMethod()]
        public void GetHtmlContentTest()
        {
            string file = File.ReadAllText("Resources\\73_2665.html");
            string remote = service.GetHtmlContent(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual(file, remote);
        }

        [TestMethod()]
        public void SetHtmlContentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTextContentSizeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTextContentTest()
        {
            string file = File.ReadAllText("Resources\\73_2665.txt");
            string remote = service.GetTextContent(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.AreEqual(file, remote);
        }

        [TestMethod()]
        public void SetTextContentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetReplyToAddressTest()
        {
            ReplyToAddress address = service.GetReplyToAddress(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Assert.IsFalse(address.Auto);
            Assert.IsTrue(address.Active);
            Assert.AreEqual("testreplyto@example.com", address.CustomEmail);
        }

        [TestMethod()]
        public void SetReplyToAddressTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetTargetGroupIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetSenderAddressTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetSubjectTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetSenderAliasTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetRecipientAliasTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTrackableLinksTest()
        {
            List<Link> links = service.GetTrackableLinks(MaileonTests.Properties.Settings.Default.mailingIdArchived, MailingFormat.HTML);
            int count = service.GetCountTrackableLinks(MaileonTests.Properties.Settings.Default.mailingIdArchived, MailingFormat.HTML);

            Assert.AreEqual(count, links.Count);

            Link link = links.First();
            Assert.AreEqual(372969L, link.Id);
            Assert.AreEqual(MailingFormat.HTML, link.Format);
            Assert.AreEqual("image", link.Layout);
            Assert.AreEqual("http://twitter.com/home?status=[SWYN|TW|TRUE]", link.Url);
        }

        [TestMethod()]
        public void GetCountTrackableLinksTest()
        {
            int count = service.GetCountTrackableLinks(MaileonTests.Properties.Settings.Default.mailingIdArchived, MailingFormat.HTML);
            List<Link> links = service.GetTrackableLinks(MaileonTests.Properties.Settings.Default.mailingIdArchived, MailingFormat.HTML);

            Assert.AreEqual(links.Count, count);
        }

        [TestMethod()]
        public void GetExternalLinksTest()
        {
            List<Link> links = service.GetExternalLinks(MaileonTests.Properties.Settings.Default.mailingIdArchived, MailingFormat.HTML);
            int count = service.GetCountExternalLinks(MaileonTests.Properties.Settings.Default.mailingIdArchived, MailingFormat.HTML);

            Assert.AreEqual(count, links.Count);

            //FIXME: need a mailing with exernal links
        }

        [TestMethod()]
        public void GetCountExternalLinksTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPersonalizationsTest()
        {
            List<Personalization> personalizations = service.GetPersonalizations(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Personalization personalization = personalizations.First();
            Assert.AreEqual("fallback", personalization.Fallbackvalue);
            Assert.IsFalse(personalization.ConditionalContentRuleId.HasValue);
            Assert.IsFalse(personalization.ConditionalContentRulesetId.HasValue);
            Assert.IsFalse(personalization.EventType.HasValue);
            Assert.IsFalse(personalization.OptionName.HasValue);
            Assert.AreEqual("EMAIL", personalization.PropertyName);
            Assert.IsFalse(personalization.OccursInConditionalContent);
        }

        [TestMethod()]
        public void GetSubjectPersonalizationsTest()
        {
            List<Personalization> personalizations = service.GetSubjectPersonalizations(MaileonTests.Properties.Settings.Default.mailingIdArchived);
            Personalization personalization = personalizations.First();
            Assert.AreEqual("fallback", personalization.Fallbackvalue);
            Assert.IsFalse(personalization.ConditionalContentRuleId.HasValue);
            Assert.IsFalse(personalization.ConditionalContentRulesetId.HasValue);
            Assert.IsFalse(personalization.EventType.HasValue);
            Assert.IsFalse(personalization.OptionName.HasValue);
            Assert.AreEqual("EMAIL", personalization.PropertyName);
            Assert.IsFalse(personalization.OccursInConditionalContent);
        }

        [TestMethod()]
        public void GetRecipientAliasPersonalizationsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetSenderAliasPersonalizationsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHtmlPersonalizationsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTextPersonalizationsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetImagesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCountHostedImagesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHostedImagesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCountExternalImagesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetExternalImagesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetJPGThumbnailTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAttachmentsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteAttachmentsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteAttachmentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddAttachmentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateAttachmentFilenameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CopyAttachmentsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCountAttachmentsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAttachmentTest()
        {
            Assert.Fail();
        }

        List<FieldType> allFields = new List<FieldType>() { FieldType.Name, FieldType.ScheduleTime, FieldType.State, FieldType.Type };
        List<MailingState> allStates = new List<MailingState>() { MailingState.Archived, MailingState.Archiving, MailingState.Blacklist, MailingState.Canceled, MailingState.Checks, MailingState.Done, MailingState.Draft, MailingState.Failed, MailingState.Paused, MailingState.Preparing, MailingState.Queued, MailingState.Released, MailingState.Sending };
        List<MailingType> allTypes = new List<MailingType>() { MailingType.Doi, MailingType.Regular, MailingType.Trigger };

        [TestMethod()]
        public void GetMailingsByCreatorNameTest()
        {
            Page<Mailing> bv = service.GetMailingsByCreatorName("balogh.viktor@maileon.hu", StringOperation.Contains, allFields, Order.Ascending, FieldType.Name, 1, 1);
            Assert.AreNotSame(0, bv.Items.Count);

            Page<Mailing> starts = service.GetMailingsByCreatorName("balogh.viktor@maileon", StringOperation.StartsWith, allFields, Order.Ascending, FieldType.Name, 1, 1);
            Page<Mailing> ends = service.GetMailingsByCreatorName("viktor@maileon.hu", StringOperation.EndsWith, allFields, Order.Ascending, FieldType.Name, 1, 1);
            Page<Mailing> contains = service.GetMailingsByCreatorName("viktor@maileon", StringOperation.Contains, allFields, Order.Ascending, FieldType.Name, 1, 1);
            Page<Mailing> equals = service.GetMailingsByCreatorName("balogh.viktor@maileon.hu", StringOperation.Equals, allFields, Order.Ascending, FieldType.Name, 1, 1);
            Page<Mailing> empty = service.GetMailingsByCreatorName(Guid.NewGuid().ToString(), StringOperation.Contains, allFields, Order.Ascending, FieldType.Name, 1, 1);

            Assert.AreEqual(equals.TotalItems, starts.TotalItems);
            Assert.AreEqual(equals.TotalItems, ends.TotalItems);
            Assert.AreEqual(equals.TotalItems, contains.TotalItems);
            Assert.AreEqual(0, empty.TotalItems);
        }

        [TestMethod()]
        public void GetMailingsByKeywordsTest()
        {
            Page<Mailing> keywords = service.GetMailingsByKeywords(new List<string>() { "1234567890" }, StringOperation.Contains, allFields, Order.Ascending, FieldType.Name, 1, 1);
            Assert.AreEqual(1, keywords.TotalItems);
        }

        [TestMethod()]
        public void GetMailingsByStatesTest()
        {
            Page<Mailing> states = service.GetMailingsByStates(allStates, allFields, null, null, 1, 1);
            Assert.AreNotEqual(0, states.TotalItems);
        }

        [TestMethod()]
        public void GetMailingsBySchedulingTimeTest()
        {
            DateTime requested = GetRandomPastDateTimeAfter(new DateTime(2013,1,1));

            Page<Mailing> before = service.GetMailingsBySchedulingTime(requested, true, allFields, null, null, 1, 20);

            foreach(Mailing m in before.Items)
            {
                Assert.IsTrue(DateTime.Compare((Timestamp)m.GetField(FieldType.ScheduleTime), requested) < 0);
            }

            Page<Mailing> after = service.GetMailingsBySchedulingTime(requested, false, allFields, null, null, 1, 20);

            foreach (Mailing m in after.Items)
            {
                Assert.IsTrue(DateTime.Compare((Timestamp)m.GetField(FieldType.ScheduleTime), requested) > 0);
            }
        }

        [TestMethod()]
        public void GetMailingsBySubjectTest()
        {
            //FIXME: GetMailingsBySubject doesn't work
            Assert.Inconclusive();

            Page<Mailing> equals = service.GetMailingsBySubject("Subjecttest öüóőúéáűíÖÜÓŐÚÉÁŰÍ", StringOperation.Equals, allFields, Order.Ascending, FieldType.Name, 1, 1);
            Page<Mailing> starts = service.GetMailingsBySubject("Subjecttest", StringOperation.StartsWith, allFields, Order.Ascending, FieldType.Name, 1, 1);
            Page<Mailing> ends = service.GetMailingsBySubject("öüóőúéáűíÖÜÓŐÚÉÁŰÍ", StringOperation.EndsWith, allFields, Order.Ascending, FieldType.Name, 1, 1);
            Page<Mailing> contains = service.GetMailingsBySubject("test öüóő", StringOperation.Contains, allFields, Order.Ascending, FieldType.Name, 1, 1);
            Page<Mailing> empty = service.GetMailingsBySubject(Guid.NewGuid().ToString(), StringOperation.Contains, allFields, Order.Ascending, FieldType.Name, 1, 1);

            Assert.AreEqual(equals.TotalItems, starts.TotalItems);
            Assert.AreEqual(equals.TotalItems, ends.TotalItems);
            Assert.AreEqual(equals.TotalItems, contains.TotalItems);
            Assert.AreEqual(0, empty.TotalItems);
        }

        [TestMethod()]
        public void GetSetDoiMailingKeyTest()
        {
            Page<Mailing> page = service.GetMailingsByTypes(new List<MailingType>() { MailingType.Doi }, new List<FieldType>() { FieldType.State }, null, null, 1, 1000);

            Assert.AreNotEqual(0, page.TotalItems);

            long doiDraftId = page.Items.Find(mailing => (MailingState)mailing.GetField(FieldType.State) == MailingState.Draft).Id;

            string originalKey = service.GetDoiMailingKey(doiDraftId);
            string key = Guid.NewGuid().ToString();

            service.SetDoiMailingKey(doiDraftId, key);
            Assert.AreEqual(key, service.GetDoiMailingKey(doiDraftId));

            service.SetDoiMailingKey(doiDraftId, originalKey);
            Assert.AreEqual(originalKey, service.GetDoiMailingKey(doiDraftId));
        }

        [TestMethod()]
        public void CreateScheduleTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetScheduleTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateScheduleTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteScheduleTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTriggerDispatchTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTriggerDispatchTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ActivateTriggerDispatchTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTriggerDispatchTest()
        {
            Assert.Fail();
        }
    }
}