using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace Maileon.Utils
{
    /// <summary>
    /// Helper class for building URLs
    /// </summary>
    internal class UrlBuilder
    {
        /// <summary>
        /// The Base URI for this builder
        /// </summary>
        public string BaseUri { get; private set; }
        /// <summary>
        /// The path for this builder
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The query parameters
        /// </summary>
        public QueryParameters QueryParameters { get; set; }

        /// <summary>
        /// Initalise a new UrlBuilder
        /// </summary>
        /// <param name="baseUri">the base URI of this url</param>
        public UrlBuilder(string baseUri)
        {
            this.BaseUri = baseUri;
        }

        /// <summary>
        /// Creates the URL string from the give path, base URI and parameters
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(this.BaseUri);
            builder.Append(this.Path);

            bool first = true;

            if (QueryParameters != null) 
            {
                foreach(KeyValuePair<string,string> parameter in QueryParameters) 
                {
                    if(first) {
                        builder.AppendFormat("?{0}={1}", HttpUtility.UrlEncode(parameter.Key), HttpUtility.UrlEncode(parameter.Value));
                    } else {
                        builder.AppendFormat("&{0}={1}", HttpUtility.UrlEncode(parameter.Key), HttpUtility.UrlEncode(parameter.Value));
                    }

                    first = false;
                }
            }

            return builder.ToString();
        }
    }
}
