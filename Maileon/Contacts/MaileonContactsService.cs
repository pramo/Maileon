using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Web;

using Maileon.Utils;

namespace Maileon.Contacts
{
    public class MaileonContactsService : AbstractMaileonService
    {
        /// <summary>
        /// The name of this service
        /// </summary>
        public static string SERVICE = "MAILEON CONTACTS";

        /// <summary>
        /// Instantiates a new maileon contacts service
        /// </summary>
        /// <param name="config">The Maileon configuration to use</param>
        public MaileonContactsService(MaileonConfiguration config): base(config, SERVICE) { }

        /// <summary>
        /// Gets the number of contacts
        /// </summary>
        /// <returns></returns>
        public int GetCountContacts()
        {
            ResponseWrapper response = Get("contacts/count");
            return SerializationUtils<int>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Creates the contact
        /// </summary>
        /// <param name="contact">the contact</param>
        /// <param name="syncMode">the maileon synchronization mode</param>
        public void CreateContact(Contact contact, SynchronizationMode syncMode)
        {
            CreateContact(contact, syncMode, null, null, false, false, null);
        }

        /// <summary>
        /// Synchronizes (updates) the contacts in the account with the data from a list of contacts and returns a detailed report with stats and validation errors
        /// </summary>
        /// <param name="contacts">List of contacts to be synchronized</param>
        /// <param name="permission">Specifies the permission to be assigned to the contact</param>
        /// <param name="syncMode">Specifies the synchronization option in case a contact with the provided identifier (external id or email address)</param>
        /// <param name="useExternalId">If set to true, the external id is used as identifier for the contacts. Otherwise the email address is used as identifier.</param>
        /// <param name="ignoreInvalidContacts">If set to true, invalid contacts are ignored and the synchronization succeeds for valid contacts.</param>
        /// <param name="overridePermission">If set to true the permission of existing and non existing contacts will be set to the given permission. If the permission is not set, permission 'none' will be set for new contacts and the permission of existing contacts will not be changed. If set to false, the permission will be used for new contacts only and the permission of existing contacts will not be changed.</param>
        /// <param name="reimportUnsubscribedContacts">If set to true unsubscribed contacts will be reimported, else, they will be ignored.</param>
        /// <param name="updateOnly">If set to true only existing contacts will be updated. Not existing contacts will not be created.</param>
        /// <returns></returns>
        public SynchronizationReport SynchronizeContacts(List<Contact> contacts, Permissions permission, SynchronizationMode syncMode, bool useExternalId, bool ignoreInvalidContacts, bool overridePermission, bool reimportUnsubscribedContacts, bool updateOnly)
        {
            if (contacts == null) 
            {
                throw new MaileonClientException("contacts cannot be null", null);
            }
            if (contacts.Count == 0)
            {
                return new SynchronizationReport();
            }

            QueryParameters parameters = new QueryParameters();
            parameters.Add("permission", (int)permission);
            parameters.Add("sync_mode", (int)syncMode);
            parameters.Add("ignore_invalid_contacts", true);
            parameters.Add("use_external_id", useExternalId);
            parameters.Add("override_permission", overridePermission);
            parameters.Add("reimport_unsubscribed_contacts", reimportUnsubscribedContacts);
            parameters.Add("update_only", updateOnly);

            ResponseWrapper response = Post("contacts", parameters, SerializationUtils<ContactCollection>.ToXmlString(contacts));
            return SerializationUtils<SynchronizationReport>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Creates the contact
        /// </summary>
        /// <param name="contact">the contact</param>
        /// <param name="syncMode">the sync mode</param>
        /// <param name="src">the src</param>
        /// <param name="subscriptionPage">the subscription page</param>
        /// <param name="doi">the doi</param>
        /// <param name="doiPlus">the doi plus</param>
        /// <param name="doiMailingKey">the doi mailing key</param>
        public void CreateContact(Contact contact, SynchronizationMode syncMode, string src, string subscriptionPage, bool doi, bool doiPlus, string doiMailingKey) 
        {
            if (contact == null) 
            {
                throw new MaileonClientException("contact cannot be null", null);
            }
            if (contact.Email == null)
            {
                throw new MaileonClientException("email address cannot be null", null);
            }

            QueryParameters parameters = new QueryParameters();
            parameters.Add("permission", (int)contact.Permission);
            parameters.Add("sync_mode", (int)syncMode);
            parameters.Add("src", src);
            parameters.Add("subscription_page", subscriptionPage);
            parameters.Add("doi", doi);
            parameters.Add("doiplus", doiPlus);
            parameters.Add("doimailing", doiMailingKey);

            //this method doesn't accept permission in the contact body
            contact.PermissionSpecified = false;
            contact.SerializeAnonymousSpecified = false;

            string xml = SerializationUtils<Contact>.ToXmlString(contact);
            Post("contacts/" + HttpUtility.UrlEncode(contact.Email), parameters, xml);
        }

        /// <summary>
        /// Gets a page of contacts
        /// </summary>
        /// <param name="standardFields">the standard fields to query</param>
        /// <param name="customFields">the custom fields to query</param>
        /// <param name="pageIndex">the idnex of the page</param>
        /// <param name="pageSize">the number of items on the page</param>
        /// <returns>a page of contacts</returns>
        public Page<Contact> GetContacts(List<StandardFieldNames> standardFields, List<string> customFields, int pageIndex, int pageSize)
        {
            ValidatePaginationParameters(pageIndex, pageSize);

            QueryParameters parameters = new QueryParameters();
            parameters.Add("page_index", pageIndex);
            parameters.Add("page_size", pageSize);
            parameters.AddList("standard_field", standardFields);
            parameters.AddList("custom_field", customFields);

            ResponseWrapper response = Get("contacts", parameters);
            Page<Contact> page = new Page<Contact>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<ContactCollection>.FromXmlString(response.Body);
            
            return page;
        }

        /// <summary>
        /// Get the contacts that match a given filter id
        /// </summary>
        /// <param name="contactFilterId">the ID of the contact filter to apply</param>
        /// <param name="standardFields">the standard fields</param>
        /// <param name="customFields">the custom fields</param>
        /// <param name="pageIndex">the page index</param>
        /// <param name="pageSize">the page size</param>
        /// <returns>a page of contacts</returns>
        public Page<Contact> GetContactsByFilterId(long contactFilterId, List<StandardFieldNames> standardFields, List<string> customFields, int pageIndex, int pageSize) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("page_index", pageIndex);
            parameters.Add("page_size", pageSize);
            parameters.AddList("standard_field", standardFields);
            parameters.AddList("custom_field", customFields);

            ResponseWrapper response = Get("contacts/filter/" + contactFilterId, parameters);
            Page<Contact> page = new Page<Contact>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<ContactCollection>.FromXmlString(response.Body);
            return page;
        }

        /// <summary>
        /// Gets a contact by email address
        /// </summary>
        /// <param name="email">the email address of the contact</param>
        /// <param name="standardFields">the standard fields</param>
        /// <param name="customFields">the custom fields</param>
        /// <returns>a contact</returns>
        public Contact GetContact(String email, List<StandardFieldNames> standardFields, List<String> customFields) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.AddList("standard_field", standardFields);
            parameters.AddList("custom_field", customFields);

            ResponseWrapper response = Get("contacts/" + HttpUtility.UrlEncode(email), parameters);
            return SerializationUtils<Contact>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Gets a contact by  Maileon ID and checksum
        /// </summary>
        /// <param name="id">the Maileon ID of the contact</param>
        /// <param name="checksum">the checksum of the contact</param>
        /// <param name="standardFields">the standard fields</param>
        /// <param name="customFields">the custom fields</param>
        /// <returns>a contact</returns>
        public Contact GetContact(long id, string checksum, List<StandardFieldNames> standardFields, List<string> customFields)
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("id", id);
            parameters.Add("checksum", checksum);
            parameters.AddList("standard_field", standardFields);
            parameters.AddList("custom_field", customFields);

            ResponseWrapper response = Get("contacts/contact", parameters);
            return SerializationUtils<Contact>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Gets a list of contacts that have the specified external ID
        /// </summary>
        /// <param name="externalId">the external ID</param>
        /// <param name="standardFields">the standard fields</param>
        /// <param name="customFields">the custom fields</param>
        /// <returns>a list of contacts</returns>
        public List<Contact> GetContactsByExternalId(string externalId, List<StandardFieldNames> standardFields, List<string> customFields)
        {
            QueryParameters parameters = new QueryParameters();
            parameters.AddList("standard_field", standardFields);
            parameters.AddList("custom_field", customFields);

            ResponseWrapper response = Get("contacts/externalid/" + HttpUtility.UrlEncode(externalId), parameters);
            return SerializationUtils<ContactCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Updates a contact using the contact's Maileon ID and checksum
        /// </summary>
        /// <param name="contact">the Maileon contact data</param>
        /// <param name="checksum">the checksum</param>
        /// <param name="triggerDoi">If provided and true (supported values are true and false) and if the permission is either 4 or 5, a doi process will be triggered for the contact.</param>
        /// <param name="src">A string intended to describe the source of the contact. If provided, the string will be stored with the doi process</param>
        /// <param name="pageKey">In case where this method was called by a landing page such as a profile update page, this string offers the possibility to keep track of it for use in reports related to doi processes</param>
        /// <param name="doiMailingKey">This parameter is ignored if triggerdoi is not provided or false. References the doi mailing to be used. If not provided, the default doi mailing will be used</param>
        /// <param name="ignoreChecksum">If this flag is set to true, the method will ignore the checksum. This flag should only be set when the call is not issued by a customer directly but by a third party application. </param>
        public void UpdateContact(Contact contact, string checksum, bool triggerDoi, string src, string pageKey, string doiMailingKey, bool ignoreChecksum) 
        {
            if (contact.Id == null) 
            {
                throw new MaileonClientException("contact id required", null);
            }

            QueryParameters parameters = new QueryParameters();
            parameters.Add("id", contact.Id);
            parameters.Add("checksum", checksum);
            parameters.Add("permission", (int)contact.Permission);
            parameters.Add("triggerdoi", triggerDoi);
            parameters.Add("src", src);
            parameters.Add("page_key", pageKey);
            parameters.Add("doimailing", doiMailingKey);
            parameters.Add("ignore_checksum", ignoreChecksum);

            //this method doesn't accept ID, external ID and permission in the contact body
            contact.IdSpecified = false;
            contact.ExternalIdSpecified = false;
            contact.PermissionSpecified = false;

            Put("contacts/contact", parameters, SerializationUtils<Contact>.ToXmlString(contact));
        }

        /// <summary>
        /// Deletes contacts based on email address
        /// </summary>
        /// <param name="email">the email address</param>
        public void DeleteContactsByEmail(string email) 
        {
            Delete("contacts/" + HttpUtility.UrlEncode(email));
        }

        /// <summary>
        /// Deletes contacts based on an external ID
        /// </summary>
        /// <param name="externalId">the external ID</param>
        public void DeleteContactsByExternalId(string externalId) {
            Delete("contacts/externalid/" + HttpUtility.UrlEncode(externalId));
        }

        /// <summary>
        /// Deletes a contact based on a Maileon ID
        /// </summary>
        /// <param name="id">the Maileon ID</param>
        public void DeleteContactByMaileonId(long id) {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("id", id);
            Delete("contacts/contact", parameters);
        }

        /// <summary>
        /// Returns a page of blocked contacts. Blocked contacts are contacts with available permission but that are blocked for sendouts because of blacklist matches or similar reasons such as bounce policy.
        /// </summary>
        /// <param name="standardFields">the standard fields</param>
        /// <param name="customFields">the custom fields</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns>a page of blocked contacts</returns>
        public Page<BlockedContact> GetBlockedContacts(List<StandardFieldNames> standardFields, List<string> customFields, int pageIndex, int pageSize) 
        {
            ValidatePaginationParameters(pageIndex, pageSize);

            QueryParameters parameters = new QueryParameters();
            parameters.Add("page_index", pageIndex);
            parameters.Add("page_size", pageSize);
            parameters.AddList("standard_field", standardFields);
            parameters.AddList("custom_field", customFields);

            ResponseWrapper response = Get("contacts/blocked", parameters);
            Page<BlockedContact> page = new Page<BlockedContact>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<BlockedContactCollection>.FromXmlString(response.Body);

            return page;
        }

        

        /// <summary>
        /// Returns the contact field backup instruction that are available in the account.
        /// </summary>
        /// <returns></returns>
        public List<FieldBackupInstruction> GetFieldBackupInstructions() 
        {
            ResponseWrapper response = Get("contacts/backup");
            return SerializationUtils<FieldBackupInstructionCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// By setting contact field backup instructions, Maileon is told to backup the values of indicated contact fields used in mailings and to map them to the mailings. This feature is expensive in terms of storage and should only be used for those contact fields that are expected to be frequently updated and that are relevant for reports.
        /// </summary>
        /// <param name="fbi"></param>
        public void CreateFieldBackupInstruction(FieldBackupInstruction fbi) 
        {
            Post("contacts/backup", SerializationUtils<FieldBackupInstruction>.ToXmlString(fbi));
        }

        /// <summary>
        /// Deletes the contact field backup instruction with the provided id in the request path. The backed up values for the contact field get also deleted by this request.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFieldBackupInstruction(long id)
        {
            Delete("contacts/backup/" + id);
        }

        /// <summary>
        /// Deletes all the contact field backup instructions in the account. The backed up values get also deleted by this request.
        /// </summary>
        public void DeleteFieldBackupInstructions()
        {
            Delete("contacts/backup");
        }

        /// <summary>
        /// Deletes the values of the given standard contact field for all contacts.
        /// </summary>
        /// <param name="field"></param>
        public void DeleteStandardFieldValues(StandardFieldNames field)
        {
            Delete("contacts/fields/standard/" + HttpUtility.UrlEncode(MaileonEnums.GetValue(field)) + "/values");
        }

        /// <summary>
        /// Deletes the values of the given custom contact field for all contacts.
        /// </summary>
        /// <param name="field"></param>
        public void DeleteCustomFieldValues(string field) 
        {
            Delete("contacts/fields/custom/" + HttpUtility.UrlEncode(field) + "/values");
        }

        /// <summary>
        /// Returns the contacts having the provided email address.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="standardFields"></param>
        /// <param name="customFields"></param>
        /// <returns></returns>
        public List<Contact> GetContactsByEmail(string email, List<StandardFieldNames> standardFields, List<string> customFields) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.AddList("standard_field", standardFields);
            parameters.AddList("custom_field", customFields);

            ResponseWrapper response = Get("contacts/email/" + HttpUtility.UrlEncode(email), parameters);
            return SerializationUtils<ContactCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Deletes the custom contact field with the provided name. Note that all the values of the field get auotmatically deleted by this call.
        /// </summary>
        /// <param name="field"></param>
        public void DeleteCustomField(string field) {
            Delete("contacts/fields/custom/" + HttpUtility.UrlEncode(field));
        }
        
        /// <summary>
        /// Gets the custom fields
        /// </summary>
        /// <returns>a list of custom fields</returns>
        public List<CustomFieldDefinition> GetCustomFields()
        {
            ResponseWrapper resp = Get("contacts/fields/custom");
            return SerializationUtils<CustomFieldDefinitionCollection>.FromXmlString(resp.Body);
        }

        /// <summary>
        /// Creates a custom field of the given type
        /// </summary>
        /// <param name="name">the name of the field</param>
        /// <param name="type">the type of the field</param>
        public void CreateCustomField(string name, CustomFieldType type) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("type", type);

            Post("contacts/fields/custom/" + HttpUtility.UrlEncode(name), parameters, null);
        }

        /// <summary>
        /// Renames a custom field
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        public void RenameCustomField(string oldName, string newName)
        {
            Put("contacts/fields/custom/" + HttpUtility.UrlEncode(oldName) + "/" + HttpUtility.UrlEncode(newName), null);
        }

        /// <summary>
        /// This method unsubscribes the contact(s) with the given email address.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="nlaccountid">Optional multivalued parameter to define in which accounts the email should be unsubscribed. Note: The accounts must belong to the owner of the API key in use, otherwise they will be ignored.</param>
        public void UnsubscribeContactsByEmail(string email, List<long> nlaccountid) 
        {
            QueryParameters parameters = new QueryParameters();

            if(nlaccountid != null) 
            {
                foreach (long id in nlaccountid) 
                {
                    parameters.Add("nlaccountid", id);
                }
            }

            Delete("contacts/" + HttpUtility.UrlEncode(email) + "/unsubscribe", parameters);
        }
    
        /// <summary>
        /// This method unsubscribes a contact using the Maileon ID.
        /// </summary>
        /// <param name="contactId"></param>
        public void UnsubscribeContactById(int contactId) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("id", contactId);
            Delete("contacts/contact/unsubscribe", parameters);
        }

        /// <summary>
        /// This method unsubscribes the contact(s) with the given external ID. Since the external ID does not need to be unique, all contacts with the given external ID will be removed.
        /// </summary>
        /// <param name="externalId"></param>
        public void UnsubscribeContactByExternalId(String externalId) 
        {
            Delete("contacts/externalid/"+ HttpUtility.UrlEncode(externalId) + "/unsubscribe");
        }

    }
}
