using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;

using Maileon.Utils;

namespace Maileon.Mailings
{
    public class MaileonMailingsService : AbstractMaileonService
    {

        public static string SERVICE = "MAILEON MAILINGS";

        public MaileonMailingsService(MaileonConfiguration config) : base(config, SERVICE) { }

        /// <summary>
        /// Creates a regular mailing and returns its id. The created mailing will include all the default settings of the account such as the default template, the default mailing list (target group), sender address etc...
        /// </summary>
        /// <param name="name">	Name of the mailing. The name must be unique within the account. The name length must be in the range from 3 to 64 and should only contain alphanumeric characters or spaces.</param>
        /// <param name="subject">The subject of the mailing. The length of the subject must not exceed 255 characters. The subject is not allowed to be empty. ISO Control characters are forbidden in the subject.</param>
        /// <returns>The ID of the newly created regular mailing</returns>
        public long CreateMailing(string name, string subject) 
        {
            return CreateMailing(name, subject, MailingType.Regular);
        }

        /// <summary>
        /// Creates a mailing and returns its id. The created mailing will include all the default settings of the account such as the default template, the default mailing list (target group), sender address etc...
        /// </summary>
        /// <param name="name">	Name of the mailing. The name must be unique within the account. The name length must be in the range from 3 to 64 and should only contain alphanumeric characters or spaces.</param>
        /// <param name="subject">The subject of the mailing. The length of the subject must not exceed 255 characters. The subject is not allowed to be empty. ISO Control characters are forbidden in the subject.</param>
        /// <param name="type">The type of the mailing</param>
        /// <returns>The ID of the newly created mailing</returns>
        public long CreateMailing(string name, string subject, MailingType type)
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("name", name);
            parameters.Add("subject", subject);
            parameters.Add("type", type);

            ResponseWrapper response = Post("mailings", parameters, null);
            return SerializationUtils<long>.FromXmlString(response.Body, "id");
        }

        /// <summary>
        /// Deletes a mailing by ID
        /// </summary>
        /// <param name="mailingId">The ID of the mailing</param>
        public void DeleteMailing(long mailingId) 
        {
            Delete("mailings/" + mailingId.ToString());
        }

        /// <summary>
        /// Sends a mailing by ID
        /// </summary>
        /// <param name="mailingId">The ID of the mailing</param>
        public void SendMailingNow(long mailingId) 
        {
            Post("mailings/" + mailingId.ToString() + "/sendnow", null);
        }

        /// <summary>
        /// Returns the archive URL of the mailing with the given id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public string GetArchiveUrl(long mailingId)
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/archiveurl");
            return response.Body;
        }

        /// <summary>
        /// Returns the type of the mailing with the given id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public MailingType GetType(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/type");
            return SerializationUtils<MailingType>.FromXmlString(response.Body, "type");
        }

        /// <summary>
        /// Returns the state of the mailing with the given id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public MailingState GetState(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/state");
            return SerializationUtils<MailingState>.FromXmlString(response.Body, "state");
        }

        /// <summary>
        /// Tells whether the mailing with the provided id is sealed. Sealed mailings have other states than “draft”.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public bool IsSealed(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/sealed");
            return SerializationUtils<bool>.FromXmlString(response.Body, "sealed");
        }

        /// <summary>
        /// Returns the name of the mailing with the given id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public string GetName(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/name");
            return SerializationUtils<string>.FromXmlString(response.Body, "name");
        }

        /// <summary>
        /// Returns the email of the author of the mailing with the given id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public string GetAuthor(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/author");
            return SerializationUtils<string>.FromXmlString(response.Body, "author");
        }

        /// <summary>
        /// Returns the id of the target group of the mailing with the given id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public long GetTargetGroupId(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/targetgroupid");
            return SerializationUtils<long>.FromXmlString(response.Body, "targetgroupid");
        }

        /// <summary>
        /// Returns the archival duration of the mailing with the provided id in months.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public int GetArchivalDuration(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/settings/archivalduration");
            return SerializationUtils<int>.FromXmlString(response.Body, "archival_duration");
        }

        /// <summary>
        /// Returns the tracking duration of the mailing with the provided id in months.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public int GetTrackingDuration(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/settings/trackingduration");
            return SerializationUtils<int>.FromXmlString(response.Body, "tracking_duration");
        }

        /// <summary>
        /// Returns the maximal allowed attachment size for the mailing with the provided id in KB.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public int GetMaxAttachmentSize(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/settings/maxattachmentsize");
            return SerializationUtils<int>.FromXmlString(response.Body, "max_attachment_size");
        }

        /// <summary>
        /// Returns the maximal allowed content size for the mailing with the provided id in KB.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public int GetMaxContentSize(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/settings/maxcontentsize");
            return SerializationUtils<int>.FromXmlString(response.Body, "max_content_size");
        }

        /// <summary>
        /// Returns the speed level of the mailing with the provided id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public SpeedLevel GetSpeedLevel(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/settings/speedlevel");
            return SerializationUtils<SpeedLevel>.FromXmlString(response.Body, "speed_level");
        }
    
        /// <summary>
        /// Sets the speed level of the mailing with the provided id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="speedLevel"></param>
        public void SetSpeedLevel(long mailingId, SpeedLevel speedLevel) 
        {
            string body = SerializationUtils<SpeedLevel>.ToXmlString(speedLevel, "speed_level");
            Post("mailings/" + mailingId.ToString() + "/settings/speedlevel", null, body);
        }

        /// <summary>
        /// Returns the tracking strategy of the mailing with the provided id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public TrackingStrategy GetTrackingStrategy(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId.ToString() + "/settings/trackingstrategy");
            return SerializationUtils<TrackingStrategy>.FromXmlString(response.Body, "tracking_strategy");
        }

        /// <summary>
        /// Sets the tracking strategy of the mailing with the provided id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public void SetTrackingStrategy(long mailingId, TrackingStrategy strategy)
        {
            string body = SerializationUtils<TrackingStrategy>.ToXmlString(strategy, "tracking_strategy");
            Post("mailings/" + mailingId.ToString() + "/settings/trackingstrategy", null, body);
        }

        /// <summary>
        /// Returns the number of DOI confirmation links in the given format of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public int GetCountDOIConfirmationLinks(long mailingId, MailingFormat format) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("format", format);

            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/doiconfirmationlinks/count", parameters);
            return SerializationUtils<int>.FromXmlString(response.Body, "count_doiconfirmationlinks");
        }

        /// <summary>
        /// Returns the number of online version links in the given format of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public int GetCountOnlineVersionLinks(long mailingId, MailingFormat format)
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("format", format);

            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/onlineversionlinks/count", parameters);
            return SerializationUtils<int>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns the number of unsubscribe links in the given format of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public int GetCountUnsubscribeLinks(long mailingId, MailingFormat format) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("format", format);

            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/unsubscribelinks/count", parameters);
            return SerializationUtils<int>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns the subject of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public string GetSubject(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/subject");
            return SerializationUtils<string>.FromXmlString(response.Body, "subject");
        }

        /// <summary>
        /// Returns the sender alias of the give mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public string GetSenderAlias(long mailingId)
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/senderalias");
            return SerializationUtils<string>.FromXmlString(response.Body, "senderalias");
        }

        /// <summary>
        /// Returns the sender address of the give mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public string GetSenderAddress(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/sender");
            return SerializationUtils<string>.FromXmlString(response.Body, "sender");
        }

        /// <summary>
        /// Returns the recipient alias of the give mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public string GetRecipientAlias(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/recipientalias");
            return SerializationUtils<string>.FromXmlString(response.Body, "recipientalias");
        }

        /// <summary>
        /// Returns the HTML content size of the given mailing id in KB
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public long GetHtmlContentSize(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/html/size");
            return SerializationUtils<int>.FromXmlString(response.Body, "html_size");
        }

        /// <summary>
        /// Returns the HTML content of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public string GetHtmlContent(long mailingId)
        {
            return Get("mailings/" + mailingId + "/contents/html", null, "text/html").Body;
        }

        /// <summary>
        /// Sets the raw HTML content of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="html"></param>
        /// <param name="doImageGrabbing">If true, referenced images in the html content will be persistent in Maileon so that they no longer need to be available under the original URL. Note that this only applies to images respecting the pattern &lt;img src=http://…" …/&gt;"</param>
        /// <param name="doLinkTracking">If this is true, links will be changed to make them trackable, if false, links will not be changed.</param>
        public void SetHtmlContent(long mailingId, string html, bool doImageGrabbing, bool doLinkTracking) 
        {
    	    QueryParameters parameters = new QueryParameters();
	        parameters.Add("doImageGrabbing", doImageGrabbing);
	        parameters.Add("doLinkTracking", doLinkTracking);
	        
            Post("mailings/" + mailingId + "/contents/html", parameters, "text/html", html);
        }

        /// <summary>
        /// Returns the text content size of the given mailing id in KB
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public long GetTextContentSize(long mailingId)
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/text/size");
            return SerializationUtils<int>.FromXmlString(response.Body, "size");
        }

        /// <summary>
        /// Returns the text content of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public string GetTextContent(long mailingId) 
        {
            return Get("mailings/" + mailingId + "/contents/text", null, "text/plain").Body;
        }

        /// <summary>
        /// Sets the text content of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="text"></param>
        public void SetTextContent(long mailingId, string text) 
        {
            Post("mailings/" + mailingId + "/contents/text", null, "text/plain", text);
        }

        /// <summary>
        /// Returns the settings for the reply-to address for this mailing.
        /// </summary>
        /// <param name="mailingId">the id of the mailing being queried</param>
        /// <returns></returns>
        public ReplyToAddress GetReplyToAddress(long mailingId)
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/settings/replyto");
            return SerializationUtils<ReplyToAddress>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Update the settings for the reply-to address for this mailing.
        /// </summary>
        /// <param name="mailingId">the id of the mailing being changed</param>
        /// <param name="replyTo">the replyto object</param>
        public void SetReplyToAddress(long mailingId, ReplyToAddress replyTo)
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("active", replyTo.Active);
            parameters.Add("auto", replyTo.Auto);
            parameters.Add("customEmail", replyTo.CustomEmail);

            Post("mailings/" + mailingId + "/settings/replyto", parameters, null);
        }

        /// <summary>
        /// Sets the target group id of the given mailing
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="tarGetgroupid"></param>
        public void SetTargetGroupId(long mailingId, long targetgroupid) 
        {
            string body = SerializationUtils<long>.ToXmlString(targetgroupid, "targetgroupid");
            Post("mailings/" + mailingId + "/targetgroupid", null, body);
        }

        /// <summary>
        /// Sets the name of the given mailing
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="name"></param>
        public void SetName(long mailingId, string name) 
        {
            string body = SerializationUtils<string>.ToXmlString(name, "name");
            Post("mailings/" + mailingId + "/name", null, body);
        }

        /// <summary>
        /// Sets the sender addres for the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="sender"></param>
        public void SetSenderAddress(long mailingId, string sender) 
        {
            string body = SerializationUtils<string>.ToXmlString(sender, "sender");
            Post("mailings/" + mailingId + "/contents/sender", null, body);
        }

        /// <summary>
        /// Sets the subject for this mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="subject"></param>
        public void SetSubject(long mailingId, string subject) 
        {
            string body = SerializationUtils<string>.ToXmlString(subject, "subject");
            Post("mailings/" + mailingId + "/contents/subject", null, body);
        }

        /// <summary>
        /// Sets the sender alias for the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="alias"></param>
        public void SetSenderAlias(long mailingId, string alias) 
        {
            string body = SerializationUtils<string>.ToXmlString(alias, "senderalias");
            Post("mailings/" + mailingId + "/contents/senderalias", null, body);
        }

        /// <summary>
        /// Sets the recipient alias for the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="alias"></param>
        public void SetRecipientAlias(long mailingId, string alias) 
        {
            string body = SerializationUtils<string>.ToXmlString(alias, "recipientalias");
            Post("mailings/" + mailingId + "/contents/recipientalias", null, body);
        }

        /// <summary>
        /// Returns a list of trackable links in the given format of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public List<Link> GetTrackableLinks(long mailingId, MailingFormat format) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("format", format);

            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/links/trackable", parameters);
            return SerializationUtils<LinkCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Returns the number of trackable links in the given format of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public int GetCountTrackableLinks(long mailingId, MailingFormat format) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("format", format);

            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/links/trackable/count", parameters);
            return SerializationUtils<int>.FromXmlString(response.Body, "count_trackable_links");
        }

        /// <summary>
        /// Returns a list of external links in the given format of the give mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public List<Link> GetExternalLinks(long mailingId, MailingFormat format) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("format", format);

            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/links/external", parameters);
            return SerializationUtils<LinkCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Returns the number of external links in the given format of the given mailing
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public int GetCountExternalLinks(long mailingId, MailingFormat format) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("format", format);
            
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/links/external/count");
            return SerializationUtils<int>.FromXmlString(response.Body, "count_external_links");
        }

        /// <summary>
        /// Returns a list of personalizations in the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public List<Personalization> GetPersonalizations(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/personalizations");
            return SerializationUtils<PersonalizationCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Returns a list of personalizations in the subject of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public List<Personalization> GetSubjectPersonalizations(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/subject/personalizations");
            return SerializationUtils<PersonalizationCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Returns a list of personalizations in the recipient alias of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public List<Personalization> GetRecipientAliasPersonalizations(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/recipientalias/personalizations");
            return SerializationUtils<PersonalizationCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Returns a list of personalizations in the sender alias of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public List<Personalization> GetSenderAliasPersonalizations(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/senderalias/personalizations");
            return SerializationUtils<PersonalizationCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Returns a list of personalizations in the HTML content of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public List<Personalization> GetHtmlPersonalizations(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/html/personalizations");
            return SerializationUtils<PersonalizationCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Returns a list of personalizations in the text content of the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public List<Personalization> GetTextPersonalizations(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/text/personalizations");
            return SerializationUtils<PersonalizationCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Returns a list of images in the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public List<Image> GetImages(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/images");
            return SerializationUtils<ImageCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Returns the number of hosted images in the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public int GetCountHostedImages(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/images/hosted/count");
            return SerializationUtils<int>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns a list of hosted images in the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public List<Image> GetHostedImages(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/images/hosted");
            return SerializationUtils<ImageCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Returns the number of external images in the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public int GetCountExternalImages(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/images/external/count");
            return SerializationUtils<int>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns a list of external images in the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public List<Image> GetExternalImages(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/contents/images/external");
            return SerializationUtils<ImageCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Returns the JPG thumbnail for the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public Stream GetJPGThumbnail(long mailingId) 
        {
            return Get("mailings/" + mailingId + "/contents/thumbnail", null, "*").Stream;
        }

        /// <summary>
        /// Returns a list of attachments for the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public List<Attachment> GetAttachments(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/attachments");
            return SerializationUtils<AttachmentCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Deletes all the attachments for the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        public void DeleteAttachments(long mailingId) 
        {
            Delete("mailings/" + mailingId + "/attachments");
        }

        /// <summary>
        /// Deletes the given attachment id for the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="attachmentId"></param>
        public void DeleteAttachment(long mailingId, long attachmentId) 
        {
            Delete("mailings/" + mailingId + "/attachments/" + attachmentId);
        }


        /// <summary>
        /// Adds an attachment to the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="stream"></param>
        /// <param name="mimeType"></param>
        /// <param name="filename"></param>
        public void AddAttachment(long mailingId, Stream stream, string mimeType, string filename) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("filename", filename);

            Post("mailings/" + mailingId + "/attachments", parameters, mimeType, stream);
        }

        /// <summary>
        /// Updates the filename for a given attachment id for the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="attachmentId"></param>
        /// <param name="filename"></param>
        public void UpdateAttachmentFilename(long mailingId, long attachmentId, string filename) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("filename", filename);

            Put("mailings/" + mailingId + "/attachments/" + attachmentId, parameters, null);
        }

        /// <summary>
        /// Copies the attachments from the source mailing id to the destionation mailing id
        /// </summary>
        /// <param name="srcMailingId"></param>
        /// <param name="destMailingId"></param>
        public void CopyAttachments(long srcMailingId, long destMailingId) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("src_mailing_id", srcMailingId);

            Put("mailings/" + destMailingId + "/attachments", parameters, null);
        }

        /// <summary>
        /// Returns the number of attachments for the given mailing id
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public int GetCountAttachments(long mailingId) 
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/attachments/count");
            return SerializationUtils<int>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Downloads the given attachment from the given mailing
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        public Stream GetAttachment(long mailingId, long attachmentId) 
        {
            return Get("mailings/" + mailingId + "/attachments/" + attachmentId, null, "*").Stream;
        }
    
        /// <summary>
        /// Returns a page of mailings in the account that match the given schedule time
        /// </summary>
        /// <param name="scheduleTime"></param>
        /// <param name="beforeSchedulingTime"></param>
        /// <param name="fields"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<Mailing> GetMailingsBySchedulingTime(Timestamp scheduleTime, bool beforeSchedulingTime, List<FieldType> fields, Order? order, FieldType? orderBy, int pageIndex, int pageSize) 
        {
            ValidatePaginationParameters(pageIndex, pageSize);
            
            QueryParameters parameters = new QueryParameters();
            parameters.Add("page_index", pageIndex);
            parameters.Add("page_size", pageSize);
            parameters.Add("scheduleTime", scheduleTime.ToString());
            parameters.Add("beforeSchedulingTime", beforeSchedulingTime);
            parameters.AddList("fields", fields);
            parameters = AddOrdering(parameters, order, orderBy);

            ResponseWrapper response = Get("mailings/filter/scheduletime", parameters);

            Page<Mailing> page = new Page<Mailing>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<MailingCollection>.FromXmlString(response.Body);
            return page;
        }
    
        /// <summary>
        /// Returns a page of mailings in the account that match the given types (one or a list)
        /// </summary>
        /// <param name="types"></param>
        /// <param name="fields"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<Mailing> GetMailingsByTypes(List<MailingType> types, List<FieldType> fields, Order? order, FieldType? orderBy, int pageIndex, int pageSize) 
        {
            ValidatePaginationParameters(pageIndex, pageSize);
            
            QueryParameters parameters = new QueryParameters();
            parameters.Add("page_index", pageIndex);
            parameters.Add("page_size", pageSize);
            parameters.AddList("fields", fields);
            parameters.AddList("types", types);
            parameters = AddOrdering(parameters, order, orderBy);

            ResponseWrapper response = Get("mailings/filter/types", parameters);

            Page<Mailing> page = new Page<Mailing>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<MailingCollection>.FromXmlString(response.Body);
            return page;
        }
    
        /**
         * Valid states are
    	         * 'draft','failed','queued','checks','blacklist','preparing','sending','paused','done','canceled','archiving','archived','released' <br />
         * <br />
         * @see MailingFields
         * 
         * @param states
         * @param fields
         * @param pageIndex
         * @param pageSize
         * @return
         * @throws MaileonException
         */
        public Page<Mailing> GetMailingsByStates(List<MailingState> states, List<FieldType> fields, Order? order, FieldType? orderBy, int pageIndex, int pageSize)
        {
            ValidatePaginationParameters(pageIndex, pageSize);

            QueryParameters parameters = new QueryParameters();
            parameters.Add("page_index", pageIndex);
            parameters.Add("page_size", pageSize);
            parameters.AddList("fields", fields);
            parameters.AddList("states", states);
            parameters = AddOrdering(parameters, order, orderBy);

            ResponseWrapper response = Get("mailings/filter/states", parameters);

            Page<Mailing> page = new Page<Mailing>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<MailingCollection>.FromXmlString(response.Body);
            return page;
        }
    

        /// <summary>
        /// Returns a page of mailings in the account that match the given keywords (one or a list)
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="keywordsOp"></param>
        /// <param name="fields"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
	    public Page<Mailing> GetMailingsByKeywords(List<string> keywords, StringOperation keywordsOp, List<FieldType> fields, Order? order, FieldType? orderBy, int pageIndex, int pageSize) 
        { 
            ValidatePaginationParameters(pageIndex, pageSize);

	        QueryParameters parameters = new QueryParameters();
	        parameters.Add("page_index", pageIndex);
	        parameters.Add("page_size", pageSize);
	        parameters.AddList("fields", fields);
	        parameters.AddList("keywords", keywords);
	        parameters.Add("keywordsOp", keywordsOp);
            parameters = AddOrdering(parameters, order, orderBy);

            ResponseWrapper response = Get("mailings/filter/keywords", parameters);

            Page<Mailing> page = new Page<Mailing>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<MailingCollection>.FromXmlString(response.Body);
            return page;
	    }

        /// <summary>
        /// Returns a page of mailings in the account that match the given creator name
        /// </summary>
        /// <param name="creatorName"></param>
        /// <param name="creatorNameOp"></param>
        /// <param name="fields"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<Mailing> GetMailingsByCreatorName(string creatorName, StringOperation creatorNameOp, List<FieldType> fields, Order? order, FieldType? orderBy, int pageIndex, int pageSize) 
        {
            ValidatePaginationParameters(pageIndex, pageSize);

            QueryParameters parameters = new QueryParameters();
            parameters.Add("page_index", pageIndex);
            parameters.Add("page_size", pageSize);
            parameters.AddList("fields", fields);
            parameters.Add("creatorName", creatorName);
            parameters.Add("creatorNameOp", creatorNameOp);
            parameters = AddOrdering(parameters, order, orderBy);

            ResponseWrapper response = Get("mailings/filter/creatorname", parameters);
	        
            Page<Mailing> page = new Page<Mailing>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<MailingCollection>.FromXmlString(response.Body);
            return page;
        }

        /// <summary>
        /// Returns a page of mailings in the account that match the given subject
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="subjectOp"></param>
        /// <param name="fields"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<Mailing> GetMailingsBySubject(string subject, StringOperation subjectOp, List<FieldType> fields, Order? order, FieldType? orderBy, int pageIndex, int pageSize) { 
            ValidatePaginationParameters(pageIndex, pageSize);

            QueryParameters parameters = new QueryParameters();
            parameters.Add("page_index", pageIndex);
            parameters.Add("page_size", pageSize);
            parameters.AddList("fields", fields);
            parameters.Add("subject", subject);
            parameters.Add("subjectOp", subjectOp);
            parameters = AddOrdering(parameters, order, orderBy);

            ResponseWrapper response = Get("mailings/filter/subject", parameters);

            Page<Mailing> page = new Page<Mailing>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<MailingCollection>.FromXmlString(response.Body);
            return page;
	    }

        private QueryParameters AddOrdering(QueryParameters parameters, Order? order, FieldType? field)
        {
            if (field.HasValue)
            {
                parameters.Add("orderBy", field.Value);
            } else
            {
                parameters.Add("orderBy", "id");
            }

            if (order.HasValue)
            {
                parameters.Add("order", order.Value);
            }
            else
            {
                parameters.Add("order", Order.Ascending);
            }

            return parameters;
        }

        /// <summary>
        /// Returns the DOI key of the mailing with the provided id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public string GetDoiMailingKey(long mailingId)
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/settings/doi_key");
            return SerializationUtils<string>.FromXmlString(response.Body, "doi_key");
        }

        /// <summary>
        /// Sets DOI key of the mailing with the provided id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="name"></param>
        public void SetDoiMailingKey(long mailingId, string name)
        {
            string body = SerializationUtils<string>.ToXmlString(name, "doi_key");
            Post("mailings/" + mailingId + "/settings/doi_key", null, body);
        }

        /// <summary>
        /// Create a new scheduling for a given mailing, using the given date.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="time"></param>
        public void CreateSchedule(long mailingId, Schedule schedule)
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("date", schedule.Date);
            parameters.Add("hour", schedule.Hours);
            parameters.Add("minutes", schedule.Minutes);

            Put("mailings/" + mailingId + "/schedule", parameters, null);
        }

        /// <summary>
        /// Returns the scheduling resource of the mailing with the provided id.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public Schedule GetSchedule(long mailingId)
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/schedule");
            return SerializationUtils<Schedule>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Update the current scheduling for a given mailing, using the given date.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public void UpdateSchedule(long mailingId, Schedule schedule)
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("date", schedule.Date);
            parameters.Add("hour", schedule.Hours);
            parameters.Add("minutes", schedule.Minutes);

            Post("mailings/" + mailingId + "/schedule", parameters, null);
        }

        /// <summary>
        /// Delete the current schedule for a given mailing.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public void DeleteSchedule(long mailingId)
        {
            Delete("mailings/" + mailingId + "/schedule");
        }

        /// <summary>
        /// Create the trigger dispatching information for a given mailing. This method needs to be called before activating a trigger mailing.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <param name="options"></param>
        public void CreateTriggerDispatch(long mailingId, TriggerDispatchOptions options)
        {
            string body = SerializationUtils<TriggerDispatchOptions>.ToXmlString(options);
            Put("mailings/" + mailingId + "/dispatching", body);
        }

        /// <summary>
        /// Get the dispatching information for a given trigger mailing.
        /// </summary>
        /// <param name="mailingId"></param>
        /// <returns></returns>
        public TriggerDispatchOptions GetTriggerDispatch(long mailingId)
        {
            ResponseWrapper response = Get("mailings/" + mailingId + "/dispatching");
            return SerializationUtils<TriggerDispatchOptions>.FromXmlString(response.Body);
        }

        /// <summary>
        /// This method activates a draft trigger mailing. It requires a valid dispatch plan to be set. 
        /// Please note, when setting the dispatching information, you can also instantly activate the trigger by setting StartTrigger to true
        /// </summary>
        /// <param name="mailingId"></param>
        public void ActivateTriggerDispatch(long mailingId)
        {
            Post("mailings/" + mailingId + "/dispatching/activate", null);
        }

        /// <summary>
        /// Once a trigger mailing is active (state = ‘sealed’) it cannot be deleted by using the usual ‘delete Mailing‘ method. 
        /// Instead this method will deactivate the trigger and remove the mailing from the active trigger mailings.
        /// </summary>
        /// <param name="mailingId"></param>
        public void DeleteTriggerDispatch(long mailingId)
        {
            Delete("mailings/" + mailingId + "/dispatching");
        }
    }
}
