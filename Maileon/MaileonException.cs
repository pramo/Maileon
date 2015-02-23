using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

using Maileon.Utils;

namespace Maileon
{
    public class MaileonException : Exception
    {
        /// <summary>
        /// The HTTP reason phrase
        /// </summary>
        public string ReasonPhrase { get; set; }
        /// <summary>
        /// The HTTP status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Instantiates a new Maileon exception.
        /// </summary>
        /// <param name="message">the message</param>
        public MaileonException(string message) : base(message) { }

        /// <summary>
        /// Instantiates a new Maileon exception
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="e">inner exception</param>
        public MaileonException(string message, Exception e) : base(message, e) { }

        /// <summary>
        /// Instantiates a new Maileon exception
        /// </summary>
        /// <param name="reason">the HTTP reason phrase</param>
        /// <param name="status">the HTTP status code</param>
        public MaileonException(HttpStatus status, string reason)
        {
            this.ReasonPhrase = reason;
            this.StatusCode = status.Code;
        }


        /// <summary>
        /// Instantiates a new Maileon exception
        /// </summary>
        /// <param name="status">the HTTP status</param>
        public MaileonException(HttpStatus status)
        {
            this.StatusCode = status.Code;
            this.ReasonPhrase = status.Reason;
        }
    }

    /// <summary>
    /// Thrown in case of client exceptions
    /// </summary>
    public class MaileonClientException : MaileonException
    {
        public MaileonClientException(string message) : base(message) { }
        public MaileonClientException(string message, Exception inner) : base(message, inner) { }
    }

    /// <summary>
    /// Thrown in case of server exceptions
    /// </summary>
    public class MaileonServerError : MaileonException
    {
        public MaileonServerError(HttpStatus status) : base(status) { }
        public MaileonServerError(string message, Exception inner) : base(message, inner) { }
    }

    /// <summary>
    /// Thrown in case of bad request exceptions
    /// </summary>
    public class MaileonBadRequestException : MaileonException 
    {
        public MaileonBadRequestException(string message) : base(message) { }
        public MaileonBadRequestException(string message, Exception inner) : base(message, inner) { }
	    public MaileonBadRequestException(HttpStatus status) : base(status) { }
        public MaileonBadRequestException(HttpStatus status, string message) : base(status, message) { }
    }

    /// <summary>
    /// Thrown in case of authorization exceptions
    /// </summary>
    public class MaileonAuthorizationException : MaileonException 
    {
        public MaileonAuthorizationException(HttpStatus status) : base(status) { }
        public MaileonAuthorizationException(string message, Exception inner) : base(message, inner) { }
        public MaileonAuthorizationException(HttpStatus status, string message) : base(status, message) { }
	}

    /// <summary>
    /// Thrown in case of access control exceptions
    /// </summary>
    public class MaileonAccessControlException : MaileonException 
    {
        public MaileonAccessControlException(HttpStatus status) : base(status) { }
        public MaileonAccessControlException(string message, Exception inner) : base(message, inner) { }
        public MaileonAccessControlException(HttpStatus status, string message) : base(status, message) { }
    }
}
