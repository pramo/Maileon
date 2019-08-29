using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maileon
{
    /// <summary>
    /// Maileon configuration
    /// </summary>
    public class MaileonConfiguration
    {
        /// <summary>
        /// The API key for this Maileon configuration
        /// </summary>
        public string APIKey { get; private set; }
        /// <summary>
        /// The Base URI for this Maileon Configuration
        /// </summary>
        public string BaseURI { get; private set; }
        /// <summary>
        /// Is debug mode enabled
        /// </summary>
        public bool Debug { get; private set; }

        public MaileonConfiguration(string APIKey, string BaseURI, bool debug = false)
        {
            this.APIKey = APIKey;
            this.BaseURI = BaseURI;
            this.Debug = debug;
        }
    }
}
