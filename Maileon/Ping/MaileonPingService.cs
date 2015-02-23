using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maileon.Ping
{
    public class MaileonPingService : AbstractMaileonService
    {
        /// <summary>
        /// The name of this service
        /// </summary>
	    public static string SERVICE = "MAILEON PING";

        /// <summary>
        /// Instantiates a new maileon contacts service.
        /// </summary>
        /// <param name="config"></param>
	    public MaileonPingService(MaileonConfiguration config) : base(config, SERVICE) {}
	
	    /// <summary>
	    /// Check the authorization of the API-Key for GET actions
	    /// </summary>
	    /// <returns></returns>
        public void CheckGet()
        {
		    Get("ping");
	    }
	
	    /// <summary>
	    /// Check the authorization of the API-Key for DELETE actions
	    /// </summary>
	    /// <returns></returns>
	    public void CheckDelete() 
        {
		    Delete("ping");
	    }
	
	    /// <summary>
	    /// Check the authorization of the API-Key for PUT actions
	    /// </summary>
	    /// <returns></returns>
	    public void CheckPut() 
        {
		    Put("ping", null);
	    }
	
	    /// <summary>
	    /// Check the authorization of the API-Key for POST actions
	    /// </summary>
	    /// <returns></returns>
	    public void CheckPost()
        {
		    Post("ping", null);
	    }
    }
}
