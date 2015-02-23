using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

using Maileon.Utils;

namespace Maileon.Contactfilters
{
    public class MaileonContactFiltersService : AbstractMaileonService 
    {
	    public static string SERVICE = "MAILEON ContactFilters";
	
	    public MaileonContactFiltersService(MaileonConfiguration config) : base(config, SERVICE) { }
	
	    /// <summary>
        /// Returns the total count of contactfilters in the account
	    /// </summary>
	    /// <returns></returns>
	    public int GetContactFiltersCount() 
        {
            ResponseWrapper response = Get("contactfilters/count");
            return SerializationUtils<int>.FromXmlString(response.Body, "count");
	    }
	
	    /// <summary>
        /// Returns a page of contactfilters in the accounts
	    /// </summary>
	    /// <param name="pageSize"></param>
	    /// <param name="pageIndex"></param>
	    /// <returns></returns>
        public Page<ContactFilter> GetContactFilters(int pageIndex, int pageSize) 
        {
            ValidatePaginationParameters(pageIndex, pageSize);

		    QueryParameters qp = new QueryParameters();
		    qp.Add("pageSize", pageSize);
            qp.Add("pageIndex", pageIndex);
		
		    ResponseWrapper response = Get("contactfilters", qp);
            Page<ContactFilter> page = new Page<ContactFilter>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<ContactFilterCollection>.FromXmlString(response.Body);

            return page;
	    }
	
	    /// <summary>
        /// Return a contactfilter using the maileon contactfilter id
	    /// </summary>
	    /// <param name="contactFilterId">The ID of the contactfilter</param>
	    /// <returns></returns>
	    public ContactFilter GetContactFilter(long contactFilterId) 
        {
		    ResponseWrapper response = Get("contactfilters/contactfilter/" + contactFilterId.ToString());

            return SerializationUtils<ContactFilter>.FromXmlString(response.Body);
	    }
	
	    /// <summary>
        /// Updates properties of a contactfilter. Currently only the name can be changed as the other values are dynamically calculated by Maileon.
	    /// </summary>
	    /// <param name="newFilterData">The contactfilter to update</param>
	    public void UpdateContactFilter(ContactFilter newFilterData) 
        {
            if(newFilterData.Id == null)
            {
                throw new MaileonClientException("contact filter id required", null);
            }

            Post("contactfilters/contactfilter/" + newFilterData.Id.ToString(), null, SerializationUtils<ContactFilter>.ToXmlString(newFilterData));		
	    }
	
	    /// <summary>
        /// Due to the possibly large number of contacts in an account, the set of contacts covered by a certain contactfilter cannot be instantly updated on every change of a contactfilter for a contact. Thus, this method provides the opportunity to trigger recalculation of the set of contacts that are matching the given filter.
	    /// </summary>
	    /// <param name="contactFilterId">The contactfilter ID to refresh</param>
        /// <param name="time">The filter is refreshed if the last update has been before the given time</param>
	    public void RefreshContactFilterContacts(long contactFilterId, Timestamp time) 
        {
    	    QueryParameters qp = new QueryParameters();
	        qp.Add("time", time);
		    Get("contactfilters/contactfilter/" + contactFilterId.ToString() + "/refresh", qp);
	    }
    }

}
