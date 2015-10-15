using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils;

namespace Maileon.Reports
{
    public class BlockParameters : AbstractParameters
    {
        /// <summary>
        /// Filter the results by reasons
        /// </summary>
        public List<BlockReason> ReasonFilter { get; set; }
        /// <summary>
        /// Filter the results by the old status
        /// </summary>
        public BlockStatus? OldStatus { get; set; }
        /// <summary>
        /// Filter the results by the new status
        /// </summary>
        public BlockStatus? NewStatus { get; set; }
        /// <summary>
        /// Whether anonymous contacts should be excluded from the results
        /// </summary>
        public bool ExcludeAnonymous { get; set; }
                
        public BlockParameters() : base() 
        {
            this.ReasonFilter = new List<BlockReason>();
        }
        public BlockParameters(AbstractParameters r)
        { 
            base.From = r.From;
            base.To = r.To;
            base.MailingIdFilter = r.MailingIdFilter;
            this.ReasonFilter = new List<BlockReason>();
            
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
            parameters.AddList("reasons", this.ReasonFilter);
            parameters.Add("old_status", this.OldStatus);
            parameters.Add("new_status", this.NewStatus);
            parameters.Add("exclude_anonymous_blocks", this.ExcludeAnonymous);

            return parameters;
        }
    }
}
