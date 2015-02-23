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

        public MaileonConfiguration(string APIKey, string BaseURI)
        {
            this.APIKey = APIKey;
            this.BaseURI = BaseURI;
        }
    }
}
