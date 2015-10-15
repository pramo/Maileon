using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

using Maileon.Reports;
using Maileon.Contacts;
using Maileon.Mailings;

namespace Maileon.Utils
{
    /// <summary>
    /// The class used to create and manipulate query parameters
    /// </summary>
    internal class QueryParameters : List<KeyValuePair<string, string>>
    {
        public QueryParameters() { }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, long value)
        {
            this.Add(new KeyValuePair<string, string>(name, value.ToString()));
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, string value)
        {
            if (value == null) return this;

            this.Add(new KeyValuePair<string, string>(name, value));
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, MailingTypes value)
        {
            this.Add(new KeyValuePair<string, string>(name, MaileonEnums.GetValue(value)));
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, CustomFieldType value)
        {
            this.Add(new KeyValuePair<string, string>(name, MaileonEnums.GetValue(value)));
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, Timestamp value)
        {
            if (value == null) return this;

            this.Add(new KeyValuePair<string, string>(name, value.TimeInMillis.ToString()));
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, long? value)
        {
            if (!value.HasValue) return this;

            this.Add(new KeyValuePair<string, string>(name, value.Value.ToString()));
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, bool value)
        {
            this.Add(new KeyValuePair<string, string>(name, value.ToString()));
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, MailingFormat? value)
        {
            if (value.HasValue)
            {
                this.Add(new KeyValuePair<string, string>(name, MaileonEnums.GetValue(value.Value)));
            }
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, StringOperation? value)
        {
            if (value.HasValue)
            {
                this.Add(new KeyValuePair<string, string>(name, MaileonEnums.GetValue(value.Value)));
            }
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, KeywordOperation? value)
        {
            if (value.HasValue)
            {
                this.Add(new KeyValuePair<string, string>(name, MaileonEnums.GetValue(value.Value)));
            }
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, BounceType? value)
        {
            if (value.HasValue)
            {
                this.Add(new KeyValuePair<string, string>(name, MaileonEnums.GetValue(value.Value)));
            }
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, BounceSource? value)
        {
            if (value.HasValue)
            {
                this.Add(new KeyValuePair<string, string>(name, MaileonEnums.GetValue(value.Value)));
            }
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, BlockStatus? value)
        {
            if (value.HasValue)
            {
                this.Add(new KeyValuePair<string, string>(name, MaileonEnums.GetValue(value.Value)));
            }
            return this;
        }

        /// <summary>
        /// Add a single parameter to the query
        /// </summary>
        /// <param name="name">the name of the parameter</param>
        /// <param name="value">the value of the parameter</param>
        /// <returns>this query</returns>
        public QueryParameters Add(string name, UnsubscriptionSource? value)
        {
            if (value.HasValue)
            {
                this.Add(new KeyValuePair<string, string>(name, MaileonEnums.GetValue(value.Value)));
            }
            return this;
        }

        /// <summary>
        /// Combine two sets of query parameters into this query
        /// </summary>
        /// <param name="parameters">the parameters to add to this query</param>
        /// <returns>this query</returns>
        public QueryParameters Add(QueryParameters parameters)
        {
            this.AddRange(parameters);
            return this;
        }

        /// <summary>
        /// Adds a list of string parameters to the query
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public QueryParameters AddList(string name, List<string> values)
        {
            if (values == null) return this;
            foreach (string elem in values)
            {
                this.Add(name, elem);
            }
            return this;
        }

        /// <summary>
        /// Adds a list of string parameters to the query
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public QueryParameters AddList(string name, List<SocialNetwork> values)
        {
            if (values == null) return this;
            foreach (SocialNetwork elem in values)
            {
                this.Add(name, MaileonEnums.GetValue(elem));
            }
            return this;
        }

        /// <summary>
        /// Adds a list of string parameters to the query
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public QueryParameters AddList(string name, List<MailingFieldNames> values)
        {
            if (values == null) return this;
            foreach (MailingFieldNames elem in values)
            {
                this.Add(name, MaileonEnums.GetValue(elem));
            }
            return this;
        }

        /// <summary>
        /// Adds a list of string parameters to the query
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public QueryParameters AddList(string name, List<MailingTypes> values)
        {
            if (values == null) return this;
            foreach (MailingTypes elem in values)
            {
                this.Add(name, MaileonEnums.GetValue(elem));
            }
            return this;
        }

        /// <summary>
        /// Adds a list of string parameters to the query
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public QueryParameters AddList(string name, List<MailingStates> values)
        {
            if (values == null) return this;
            foreach (MailingStates elem in values)
            {
                this.Add(name, MaileonEnums.GetValue(elem));
            }
            return this;
        }

        /// <summary>
        /// Adds a list of long parameters to the query
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public QueryParameters AddList(string name, List<long> values)
        {
            if (values == null) return this;
            foreach (long elem in values)
            {
                this.Add(name, elem.ToString());
            }
            return this;
        }

        /// <summary>
        /// Adds a list of StandardFieldNames parameters to the query
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public QueryParameters AddList(string name, List<StandardFieldNames> values)
        {
            if (values == null) return this;
            foreach (StandardFieldNames elem in values)
            {
                this.Add(name, MaileonEnums.GetValue(elem));
            }
            return this;
        }

        /// <summary>
        /// Adds a list of BlockReason parameters to the query
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public QueryParameters AddList(string name, List<BlockReason> values)
        {
            if (values == null) return this;
            foreach (BlockReason elem in values)
            {
                this.Add(name, MaileonEnums.GetValue(elem));
            }
            return this;
        }

        /// <summary>
        /// Adds a list of DeviceType parameters to the query
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public QueryParameters AddList(string name, List<DeviceType> values)
        {
            if (values == null) return this;
            foreach (DeviceType elem in values)
            {
                this.Add(name, MaileonEnums.GetValue(elem));
            }
            return this;
        }

        /// <summary>
        /// Adds a list of DeviceType parameters to the query
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public QueryParameters AddList(string name, List<MailingFormat> values)
        {
            if (values == null) return this;
            foreach (MailingFormat elem in values)
            {
                this.Add(name, MaileonEnums.GetValue(elem));
            }
            return this;
        }
    }
    
}
