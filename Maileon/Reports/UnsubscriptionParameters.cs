using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils;

namespace Maileon.Reports
{
    public class UnsubscriptionParameters : AbstractParameters
    {
        /// <summary>
        /// Filter the results by source
        /// </summary>
        public UnsubscriptionSource? SourceFilter { get; set; }

        public UnsubscriptionParameters() : base() { }
        public UnsubscriptionParameters(AbstractParameters r)
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

            parameters.Add("source", this.SourceFilter);

            return parameters;
        }
    }
}
