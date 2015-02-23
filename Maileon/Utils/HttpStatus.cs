using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace Maileon
{
    /// <summary>
    /// Helper class for dealing with HTTP statuses
    /// </summary>
    public class HttpStatus
    {
        public enum HttpStatusCodeFamily{ SUCCESSFUL, CLIENT_ERROR, SERVER_ERROR, OTHER };

        /// <summary>
        /// Helper function to determine the status code family
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private HttpStatusCodeFamily DetermineStatusCodeFamily(HttpStatusCode status) {
            int statusCode = (int)status;

            if (statusCode > 499) return HttpStatusCodeFamily.SERVER_ERROR;
            if (statusCode > 399) return HttpStatusCodeFamily.CLIENT_ERROR;
            if (statusCode > 299) return HttpStatusCodeFamily.OTHER;
            if (statusCode > 199) return HttpStatusCodeFamily.SUCCESSFUL;
            return HttpStatusCodeFamily.OTHER;
        }

        /// <summary>
        /// Returns the code associated with this HTTP status
        /// </summary>
        public HttpStatusCode Code { get; private set; }
        /// <summary>
        /// Returns the HTTP reason phrase
        /// </summary>
        public string Reason { get; private set; }
        /// <summary>
        /// Returns the HTTP status code family
        /// </summary>
        public HttpStatusCodeFamily Family { get; private set; }

        /// <summary>
        /// Creates a HTTP status based on a status code and a reason phrase
        /// </summary>
        /// <param name="code"></param>
        /// <param name="reason"></param>
        public HttpStatus(HttpStatusCode code, string reason)
        {
            this.Code = code;
            this.Family = DetermineStatusCodeFamily(code);
            this.Reason = reason;
        }
    }
}
