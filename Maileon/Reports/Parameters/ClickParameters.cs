using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils;

namespace Maileon.Reports
{
    public class ClickParameters : AbstractParameters
    {       
        /// <summary>
        /// Filter the results by format
        /// </summary>
        public MailingFormat? FormatFilter {get;set;}
        /// <summary>
        /// Filter the results by link id
        /// </summary>
        public List<long> LinkIdFilter { get; set; }
        /// <summary>
        /// Filter the result by link url
        /// </summary>
        public string LinkUrlFilter { get; set; }
        /// <summary>
        /// Filter the results by link tag
        /// </summary>
        public List<string> LinkTagFilter { get; set; }
        /// <summary>
        /// Filter the results by social network
        /// </summary>
        public List<SocialNetwork> SocialNetworkFilter { get; set; }
        /// <summary>
        /// Filter the results by device type
        /// </summary>
        public List<DeviceType> DeviceTypeFilter { get; set; }
        /// <summary>
        /// Whether the results should contain email client information
        /// </summary>
        public bool EmbedEmailClientInfos { get; set; }
        /// <summary>
        /// Whether anonymous contacts should be excluded from the results
        /// </summary>
        public bool ExcludeAnonymous { get; set; }

        public ClickParameters() : base()
        {
            this.LinkIdFilter = new List<long>();
            //this.LinkUrlFilter = new List<string>();
            this.LinkTagFilter = new List<string>();
            this.SocialNetworkFilter = new List<SocialNetwork>();
            this.DeviceTypeFilter = new List<DeviceType>();
        }
        
        public ClickParameters(AbstractParameters r)
        { 
            base.From = r.From;
            base.To = r.To;
            base.StandardFields = r.StandardFields;
            base.CustomFields = r.CustomFields;
            base.EmbedFieldBackups = r.EmbedFieldBackups;
            base.MailingIdFilter = r.MailingIdFilter;
            this.LinkIdFilter = new List<long>();
            this.LinkTagFilter = new List<string>();
            this.SocialNetworkFilter = new List<SocialNetwork>();
            this.DeviceTypeFilter = new List<DeviceType>();
        }

        internal override QueryParameters GetQueryParameters()
        {
            QueryParameters parameters = CreateQueryParameters(
                    this.From, this.To,
                    this.MailingIdFilter, this.ContactIdFilter, this.ContactEmailFilter, this.ContactExternalIdFilter,
                    this.EmbedFieldBackups);

            parameters.Add("format", this.FormatFilter);
            parameters.AddList("social_network", this.SocialNetworkFilter);
            parameters.AddList("device_type", this.DeviceTypeFilter);
            parameters.Add("embed_email_client_infos", this.EmbedEmailClientInfos);
            parameters.AddList("standard_field", this.StandardFields);
            parameters.AddList("custom_field", this.CustomFields);
            parameters.AddList("link_id", this.LinkIdFilter);
            parameters.Add("link_url", this.LinkUrlFilter);
            parameters.AddList("link_tag", this.LinkTagFilter);
            parameters.Add("exclude_anonymous_clicks", this.ExcludeAnonymous);

            return parameters;
        }
    }
}
