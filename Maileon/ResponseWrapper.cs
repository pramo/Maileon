using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Xml;

namespace Maileon
{
    /// <summary>
    /// A class for wrapping HTTP responses
    /// </summary>
    internal class ResponseWrapper
    {
        /// <summary>
        /// The HTTP status
        /// </summary>
        public HttpStatus Status { get; private set; }

        /// <summary>
        /// The HTTP reason phrase
        /// </summary>
        public string ReasonPhrase { get; private set; }

        /// <summary>
        /// The headers
        /// </summary>
        public WebHeaderCollection Headers { get; private set; }

        /// <summary>
        /// The type of the media
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// The response body
        /// </summary>
        public string Body { get; private set; }

        public Stream Stream { get; private set; }

        /// <summary>
        /// Creates a wrapped response from the given HttpWebResponse
        /// </summary>
        /// <param name="response">the source web response</param>
        public ResponseWrapper(HttpWebResponse response)
        {
            this.Status = new HttpStatus(response.StatusCode, response.StatusDescription);
            this.ReasonPhrase = response.StatusDescription;
            this.Headers = response.Headers;
            this.Type = response.ContentType;
            this.Stream = response.GetResponseStream();

            using(TextReader reader = new StreamReader(this.Stream)) 
            {
                this.Body = reader.ReadToEnd();
            }
        }
    }
}
