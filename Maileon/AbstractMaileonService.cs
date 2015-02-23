using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Net;
using System.Xml;
using Diagnostics = System.Diagnostics;

using Maileon.Contacts;
using Maileon.Utils;

namespace Maileon
{
    /// <summary>
    /// The abstract Maileon service used for implementing all the maileon services
    /// </summary>
    public abstract class AbstractMaileonService
    {
        /// <summary>
        /// The Maileon XML MIME type constant
        /// </summary>
        public static string MAILEON_XML_TYPE = "application/vnd.maileon.api+xml; charset=utf-8";

        /// <summary>
        /// The Maileon JSON MIME type constant
        /// </summary>
        public static string MAILEON_JSON_TYPE = "application/json; charset=utf-8";

        /// <summary>
        /// The MaileonConfiguration of this service
        /// </summary>
        private MaileonConfiguration config;

        /// <summary>
        /// The encoded api key
        /// </summary>
        private string encodedApiKey;

        /// <summary>
        /// Whether debug mode is enabled
        /// </summary>
        public bool Debug { get; set; }

        /// <summary>
        /// The name of this service
        /// </summary>
        protected string service;

        /// <summary>
        /// Instantiates a new abstract maileon service.
        /// </summary>
        /// <param name="config">the config</param>
        /// <param name="service">the service name</param>
        public AbstractMaileonService(MaileonConfiguration config, String service) 
        {
            this.config = config;
            this.encodedApiKey =  Base64Encode(config.APIKey);
            this.service = service;
#if DEBUG
            this.Debug = true;
#endif

        }

        /// <summary>
        /// Helper function for encoding in Base64
        /// </summary>
        /// <param name="plainText">the plaintext to encode</param>
        /// <returns>Base64 encoded version of the argument</returns>
        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        #region GET 
        /// <summary>
        /// Performs a GET request with the given path
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <returns></returns>
        internal ResponseWrapper Get(string path) 
        {
            return Get(path, null, MAILEON_XML_TYPE);
        }

        /// <summary>
        /// Performs a GET request with the given path and parameters
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <param name="parameters">the parameters of the request</param>
        /// <returns></returns>
        internal ResponseWrapper Get(String path, QueryParameters parameters) 
        {
            return Get(path, parameters, MAILEON_XML_TYPE);
        }

        /// <summary>
        /// Performs a GET request with the given path, parameters and MIME type
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <param name="parameters">the parameters of the request</param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        internal ResponseWrapper Get(String path, QueryParameters parameters, string mimeType) 
        {
            return GetResponse(HttpWebRequestMethod.GET, path, parameters, mimeType, (string)null);
        }
        #endregion

        #region POST
        /// <summary>
        /// Performs a POST request with the given path and body data
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <param name="body">the body of the request</param>
        /// <returns></returns>
        internal ResponseWrapper Post(string path, string body)
        {
            return Post(path, null, MAILEON_XML_TYPE, body);
        }

        /// <summary>
        /// Performs a POST request with the given path, body data and parameters
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <param name="parameters">the parameters of the request</param>
        /// <param name="body">the body of the request</param>
        /// <returns></returns>
        internal ResponseWrapper Post(string path, QueryParameters parameters, string body)
        {
            return Post(path, parameters, MAILEON_XML_TYPE, body);
        }

        /// <summary>
        /// Performs a POST request with the given path, body data and parameters
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <param name="parameters">the parameters of the request</param>
        /// <param name="mimeType">the MIME type of the request</param>
        /// <param name="body">the body of the request</param>
        /// <returns></returns>
        internal ResponseWrapper Post(string path, QueryParameters parameters, string mimeType, string body)
        {
            return GetResponse(HttpWebRequestMethod.POST, path, parameters, mimeType, body);
        }

        /// <summary>
        /// Performs a POST request with the given path, body stream and parameters
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <param name="parameters">the parameters of the request</param>
        /// <param name="mimeType">the MIME type of the request</param>
        /// <param name="body">the body of the request</param>
        /// <returns></returns>
        internal ResponseWrapper Post(string path, QueryParameters parameters, string mimeType, Stream body)
        {
            return GetResponse(HttpWebRequestMethod.POST, path, parameters, mimeType, body);
        }

        #endregion

        #region PUT
        /// <summary>
        /// Performs a PUT request with the given path, body data and parameters
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <param name="body">the body of the request</param>
        /// <returns></returns>
        internal ResponseWrapper Put(string path, string body) 
        {
            return Put(path, null, MAILEON_XML_TYPE, body);
        }

        /// <summary>
        /// Performs a PUT request with the given path, body data and parameters
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <param name="parameters">the parameters of the request</param>
        /// <param name="body">the body of the request</param>
        /// <returns></returns>
        internal ResponseWrapper Put(string path, QueryParameters parameters, string body)
        {
            return Put(path, parameters, MAILEON_XML_TYPE, body);
        }

        /// <summary>
        /// Performs a PUT request with the given path, body data and parameters
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <param name="parameters">the parameters of the request</param>
        /// <param name="mimeType">the MIME type of the request</param>
        /// <param name="body">the body of the request</param>
        /// <returns></returns>
        internal ResponseWrapper Put(string path, QueryParameters parameters, string mimeType, string body)
        {
            return GetResponse(HttpWebRequestMethod.PUT, path, parameters, mimeType, body);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Performs a DELETE request with the given path, body data and parameters
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <returns></returns>
        internal ResponseWrapper Delete(string path)
        {
            return Delete(path, null, MAILEON_XML_TYPE);
        }

        /// <summary>
        /// Performs a DELETE request with the given path, body data and parameters
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <param name="parameters">the parameters of the request</param>
        /// <returns></returns>
        internal ResponseWrapper Delete(String path, QueryParameters parameters)
        {
            return Delete(path, parameters, MAILEON_XML_TYPE);
        }

        /// <summary>
        /// Performs a DELETE request with the given path, body data and parameters
        /// </summary>
        /// <param name="path">the path of the request</param>
        /// <param name="parameters">the parameters of the request</param>
        /// <param name="mimeType">the MIME type of the request</param>
        /// <returns></returns>
        internal ResponseWrapper Delete(string path, QueryParameters parameters, string mimeType)
        {
            return GetResponse(HttpWebRequestMethod.DELETE, path, parameters, mimeType, (string)null);

        }
        #endregion

        /// <summary>
        /// Creates and runs a request with the given HTTP parameters
        /// </summary>
        /// <param name="method">the HTTP method</param>
        /// <param name="path">the HTTP path</param>
        /// <param name="parameters">the query parameters</param>
        /// <param name="mimeType">the accept/contenttype header</param>
        /// <returns></returns>
        private ResponseWrapper GetResponse(HttpWebRequestMethod method, string path, QueryParameters parameters, string mimeType, string data) 
        {
            HttpWebRequest request = CreateRequest(method, path, parameters, mimeType);

            if(method == HttpWebRequestMethod.POST || method == HttpWebRequestMethod.PUT ) 
            { 
                request.ContentType = mimeType;

                using (TextWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(data);
                }
            }
            
            DebugPrintRequest(request, data);

            //return the response wrapped
            return DoRequest(request);
        }

        /// <summary>
        /// Creates and runs a request with the given HTTP parameters
        /// </summary>
        /// <param name="method">the HTTP method</param>
        /// <param name="path">the HTTP path</param>
        /// <param name="parameters">the query parameters</param>
        /// <param name="mimeType">the accept/contenttype header</param>
        /// <returns></returns>
        private ResponseWrapper GetResponse(HttpWebRequestMethod method, string path, QueryParameters parameters, string mimeType, Stream data)
        {
            HttpWebRequest request = CreateRequest(method, path, parameters, mimeType);

            if (method == HttpWebRequestMethod.POST || method == HttpWebRequestMethod.PUT)
            {
                request.ContentType = mimeType;
                data.CopyTo(request.GetRequestStream());
            }

            DebugPrintRequest(request, "<binary data>");

            //return the response wrapped
            return DoRequest(request);
        }

        private HttpWebRequest CreateRequest(HttpWebRequestMethod method, string path, QueryParameters parameters, string mimeType)
        {
            //build the URL with the given parts
            UrlBuilder url = new UrlBuilder(config.BaseURI);
            url.Path = path;
            url.QueryParameters = parameters;

            //create a request with the given method/headers/contenttype
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.ToString());
            request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + encodedApiKey);
            request.Accept = mimeType;
            request.Method = Enum.GetName(typeof(HttpWebRequestMethod), method);

            return request;
        }

        /// <summary>
        /// Helper enum used to list available HTTP methods
        /// </summary>
        private enum HttpWebRequestMethod { GET, POST, PUT, DELETE }
    
        /// <summary>
        /// Gets a responsewrapper object from a request and analyze exceptions
        /// </summary>
        /// <param name="resp">the response to analyze</param>
        private ResponseWrapper DoRequest(WebRequest request) 
        {
            try
            {
                ResponseWrapper wrappedResponse = new ResponseWrapper((HttpWebResponse)request.GetResponse());

                DebugPrintResponse(wrappedResponse);

                return wrappedResponse;
            }
            catch (WebException we)
            {
                HttpWebResponse response = (HttpWebResponse)we.Response;

                if (response != null)
                {
                    ResponseWrapper wrappedResponse = new ResponseWrapper(response);

                    DebugPrintResponse(wrappedResponse);

                    String message = ParseErrorMsg(wrappedResponse);

                    switch (response.StatusCode) 
                    {
                        case HttpStatusCode.Unauthorized:
                            throw new MaileonAuthorizationException(message, we);
                        case HttpStatusCode.Forbidden:
                            throw new MaileonAccessControlException(message, we);
                        case HttpStatusCode.BadRequest:
                            throw new MaileonBadRequestException(message, we);
                        case HttpStatusCode.InternalServerError:
                            throw new MaileonException(message, we);
                        case HttpStatusCode.ServiceUnavailable:
                            throw new MaileonBadRequestException(message, we);
                        default:
                            throw new MaileonException(message, we);
                    }
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Prints the given request to the debug window
        /// </summary>
        /// <param name="request">the request to print</param>
        /// <param name="body">the body of the request</param>
        private void DebugPrintRequest(HttpWebRequest request, string body)
        {
            if(Debug)
            { 
                Diagnostics.Debug.WriteLine("Request:");
                Diagnostics.Debug.WriteLine(request.Method + " " + request.RequestUri.ToString());

                for (int i = 0; i < request.Headers.Count; i++)
                {
                    Diagnostics.Debug.WriteLine(request.Headers.Keys[i] + ": " + string.Join(" ", request.Headers.GetValues(i)));
                }

                Diagnostics.Debug.WriteLine(string.Empty);
                if (body != null) { Diagnostics.Debug.WriteLine(body); }
            }
        }

        /// <summary>
        /// Prints the given wrapped response to the debug window
        /// </summary>
        /// <param name="response">the response to print</param>
        private void DebugPrintResponse(ResponseWrapper response)
        {
            if (Debug)
            {
                Diagnostics.Debug.WriteLine("Response:");
                Diagnostics.Debug.WriteLine(string.Format("{0} {1}", (int)response.Status.Code, response.Status.Reason));

                for (int i = 0; i < response.Headers.Count; i++)
                {
                    Diagnostics.Debug.WriteLine(response.Headers.Keys[i] + ": " + string.Join(" ", response.Headers.GetValues(i)));
                }

                if (response.Body != null) { Diagnostics.Debug.WriteLine(response.Body); }
            }
        }

        /// <summary>
        /// Parses the error message
        /// </summary>
        /// <param name="resp">the response to parse</param>
        /// <returns></returns>
        private string ParseErrorMsg(ResponseWrapper resp) 
        {
            if(MAILEON_XML_TYPE.StartsWith(resp.Type))
            {
                try 
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(resp.Body);
                    XmlElement error = doc.DocumentElement;
                    string message = error.GetElementsByTagName("message")[0].InnerText;

                    return message;
                } catch (Exception) {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// Validates whether the pageindex and pagesize are > 0
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        protected void ValidatePaginationParameters(int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
            {
                throw new MaileonBadRequestException("pageIndex must be > 0 - found: " + pageIndex);
            }
            if (pageSize < 1)
            {
                throw new MaileonBadRequestException("pageSize must be > 0 - found: " + pageSize);
            }
        }
    }
}
