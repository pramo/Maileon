using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils;

namespace Maileon.Reports
{
    public class BounceParameters : AbstractParameters
    {
        /// <summary>
        /// Filter the results by statuscodes
        /// </summary>
        public List<string> StatusCodeFilter { get; set; }
        /// <summary>
        /// Filter the results by bounce type
        /// </summary>
        public BounceType? TypeFilter { get; set; }
        /// <summary>
        /// Filter the results by bounce source
        /// </summary>
        public BounceSource? SourceFilter { get; set; }
        /// <summary>
        /// Whether anonymous contacts should be excluded from the results
        /// </summary>
        public bool ExcludeAnonymous { get; set; }
                
        public BounceParameters() : base() 
        {
            this.StatusCodeFilter = new List<string>();
        }
        public BounceParameters(AbstractParameters r)
        { 
            base.From = r.From;
            base.To = r.To;
            base.MailingIdFilter = r.MailingIdFilter;
            this.StatusCodeFilter = new List<string>();
            
            base.StandardFields = r.StandardFields;
            base.CustomFields = r.CustomFields;
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
            parameters.AddList("status_code", this.StatusCodeFilter);
            parameters.Add("type", this.TypeFilter);
            parameters.Add("source", this.SourceFilter);
            parameters.Add("exclude_anonymous_bounces", this.ExcludeAnonymous);

            return parameters;
        }
    }
}
