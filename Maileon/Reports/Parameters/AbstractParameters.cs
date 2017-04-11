using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils;
using Maileon.Contacts;

namespace Maileon.Reports
{
    public abstract class AbstractParameters
    {
        /// <summary>
        /// If provided, only the events after the given date will be returned.
        /// </summary>
        public Timestamp From { get; set; }
        /// <summary>
        /// If provided, only the events before the given date will be returned. 
        /// </summary>
        public Timestamp To { get; set; }
        /// <summary>
        /// Each value must correspond to a mailing id.
        /// </summary>
        public List<long> MailingIdFilter { get; set; }
        /// <summary>
        /// Filter the results by contacts. Each value must correspond to a contact id.
        /// </summary>
        public List<long> ContactIdFilter { get; set;}
        /// <summary>
        /// Filter the results by email addresses.
        /// </summary>
        public List<string> ContactEmailFilter { get; set;}
        /// <summary>
        /// Filter the results by external ids. Each value must correspond to a contacts external id
        /// </summary>
        public List<string> ContactExternalIdFilter { get; set;}
        /// <summary>
        /// Query the value of a standard contact field.
        /// </summary>
        public List<StandardFieldName> StandardFields { get; set; }
        /// <summary>
        /// Query the value of a custom contact field.
        /// </summary>
        public List<string> CustomFields { get; set; }
        /// <summary>
        /// Field Backups are the values of contact fields that have been backed up for mailings because of a backup instruction. For each event, the corresponding field backups will be returned if available.
        /// </summary>
        public bool EmbedFieldBackups { get; set; }

        public AbstractParameters()
        {
            this.From = null;
            this.To = null;
            this.MailingIdFilter = new List<long>();
            this.StandardFields = new List<StandardFieldName>();
            this.CustomFields = new List<string>();
        }

        internal abstract QueryParameters GetQueryParameters();

        /// <summary>
        /// Creates query parameters with the given variables
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="mailingIdFilter"></param>
        /// <param name="contactIdFilter"></param>
        /// <param name="contactEmailFilter"></param>
        /// <param name="contactExternalIdFilter"></param>
        /// <param name="embedFieldBackups"></param>
        /// <returns></returns>
        internal static QueryParameters CreateQueryParameters(
            Timestamp fromDate, Timestamp toDate, List<long> mailingIdFilter,
            List<long> contactIdFilter, List<string> contactEmailFilter,
            List<string> contactExternalIdFilter, bool embedFieldBackups)
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("from_date", fromDate);
            parameters.Add("to_date", toDate);
            parameters.AddList("mailing_id", mailingIdFilter);
            parameters.AddList("ids", contactIdFilter);
            parameters.AddList("emails", contactEmailFilter);
            parameters.AddList("eids", contactExternalIdFilter);
            parameters.Add("embed_field_backups", embedFieldBackups);

            return parameters;
        }
    }
}
