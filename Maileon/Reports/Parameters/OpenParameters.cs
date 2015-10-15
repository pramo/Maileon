using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils;

namespace Maileon.Reports
{
    public class OpenParameters : AbstractParameters
    {
        /// <summary>
        /// Filters the opens by format.
        /// </summary>
        public MailingFormat? FormatFilter { get; set; }
        /// <summary>
        /// Filter the opens by the social networks where they occurred.
        /// </summary>
        public List<SocialNetwork> SocialNetworkFilter { get; set; }
        /// <summary>
        /// Filter the opens by device type.
        /// </summary>
        public List<DeviceType> DeviceTypeFilter { get; set; }
        /// <summary>
        /// If the set to true, available email client details will be appended to each open.
        /// </summary>
        public bool EmbedEmailClientInfos { get; set; }
        /// <summary>
        /// If set to true, the opens that cannot be mapped to contacts because of permission types or because unsubscriptions are omitted in the results.
        /// </summary>
        public bool ExcludeAnonymous { get; set; }

        public OpenParameters()
            : base()
        {
            this.SocialNetworkFilter = new List<SocialNetwork>();
            this.DeviceTypeFilter = new List<DeviceType>();
        }

        public OpenParameters(AbstractParameters r)
        {
            base.From = r.From;
            base.To = r.To;
            base.StandardFields = r.StandardFields;
            base.CustomFields = r.CustomFields;
            base.EmbedFieldBackups = r.EmbedFieldBackups;
            base.MailingIdFilter = r.MailingIdFilter;
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
            parameters.Add("exclude_anonymous_opens", this.ExcludeAnonymous);

            return parameters;
        }
    }
}
