using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils;

namespace Maileon.Reports
{
    public class RecipientParameters : AbstractParameters
    {
        /// <summary>
        /// Whether deleted contacts should be excluded from the results
        /// </summary>
        public bool ExcludeDeleted { get; set; }

        public RecipientParameters() : base() { }
        public RecipientParameters(AbstractParameters r)
        { 
            base.From = r.From;
            base.To = r.To;
            base.StandardFields = r.StandardFields;
            base.CustomFields = r.CustomFields;
            base.EmbedFieldBackups = r.EmbedFieldBackups;
            base.MailingIdFilter = r.MailingIdFilter;
        }

        internal override QueryParameters GetQueryParameters()
        {
            QueryParameters parameters = CreateQueryParameters(
                this.From, this.To,
                this.MailingIdFilter, this.ContactIdFilter, this.ContactEmailFilter, this.ContactExternalIdFilter,
                this.EmbedFieldBackups);

            parameters.AddList("standard_field", this.StandardFields);
            parameters.AddList("custom_field", this.CustomFields);
            parameters.Add("exclude_deleted_recipients", this.ExcludeDeleted);

            return parameters;
        }
    }
}
