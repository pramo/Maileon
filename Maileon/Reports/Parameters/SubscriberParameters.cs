using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils;

namespace Maileon.Reports
{
    public class SubscriberParameters : AbstractParameters
    {
        /// <summary>
        /// Whether anonymous contacts should be excluded from the results
        /// </summary>
        public bool ExcludeAnonymous { get; set; }

        public SubscriberParameters() : base() { }
        public SubscriberParameters(AbstractParameters r)
        { 
            base.From = r.From;
            base.To = r.To;
            base.MailingIdFilter = r.MailingIdFilter;
            base.EmbedFieldBackups = r.EmbedFieldBackups;
        }

        internal override QueryParameters GetQueryParameters()
        {
            QueryParameters parameters = CreateQueryParameters(
                this.From, this.To,
                this.MailingIdFilter, this.ContactIdFilter, this.ContactEmailFilter, this.ContactExternalIdFilter,
                this.EmbedFieldBackups);

            parameters.AddList("standard_field", this.StandardFields);
            parameters.AddList("custom_field", this.CustomFields);
            parameters.Add("exclude_anonymous_clicks", this.ExcludeAnonymous);

            return parameters;
        }
    }
}
