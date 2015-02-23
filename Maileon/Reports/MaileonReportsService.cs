using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

using Maileon.Utils;
using Maileon.Contacts;

namespace Maileon.Reports
{
    public class MaileonReportsService : AbstractMaileonService
    {
        public static string SERVICE = "MAILEON REPORTS";

        public MaileonReportsService(MaileonConfiguration config) : base(config, SERVICE) { }

        /// <summary>
        /// Returns a page of open events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <param name="pageIndex">the index of the page</param>
        /// <param name="pageSize">the size of the page</param>
        /// <returns>a page of open events</returns>
        public Page<Open> GetOpens(OpenParameters options, int pageIndex, int pageSize)
        {
            QueryParameters parameters = CreatePageQueryParameters(pageIndex, pageSize, options);

            ResponseWrapper response = Get("reports/opens", parameters);
            Page<Open> page = new Page<Open>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<OpenCollection>.FromXmlString(response.Body);

            return page;
        }

        /// <summary>
        /// Returns a page of unique open events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <param name="pageIndex">the index of the page</param>
        /// <param name="pageSize">the size of the page</param>
        /// <returns>a page of unique open events</returns>
        public Page<Open> GetOpensUnique(OpenParameters options, int pageIndex, int pageSize)
        {
            QueryParameters parameters = CreatePageQueryParameters(pageIndex, pageSize, options);

            ResponseWrapper response = Get("reports/opens/unique", parameters);
            Page<Open> page = new Page<Open>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<OpenCollection>.FromXmlString(response.Body);

            return page;
        }

        /// <summary>
        /// Returns the number of open events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <returns>the number of open events</returns>
        public long GetOpensCount(OpenParameters options)
        {
            QueryParameters parameters = options.GetQueryParameters();
            ResponseWrapper response = Get("reports/opens/count", parameters);
            return SerializationUtils<long>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns the number of unique open eventss based on the specified parameters
        /// </summary>
        /// <param name="options">the options</param>
        /// <returns>the number of unique open events</returns>
        public long GetOpensUniqueCount(OpenParameters options)
        {
            QueryParameters parameters = options.GetQueryParameters();
            ResponseWrapper response = Get("reports/opens/count", parameters);
            return SerializationUtils<long>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns a page of recipient events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <param name="pageIndex">the index of the page</param>
        /// <param name="pageSize">the size of the page</param>
        /// <returns>a page of recipient events</returns>
        public Page<Recipient> GetRecipients(RecipientParameters options, int pageIndex, int pageSize)
        {
            QueryParameters parameters = CreatePageQueryParameters(pageIndex, pageSize, options);

            ResponseWrapper response = Get("reports/recipients", parameters);
            Page<Recipient> page = new Page<Recipient>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<RecipientCollection>.FromXmlString(response.Body);
            
            return page;
        }

        /// <summary>
        /// Returns the number of recipient events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <returns>the number of recipient events</returns>
        public long GetRecipientsCount(RecipientParameters options)
        {
            QueryParameters parameters = options.GetQueryParameters();
            ResponseWrapper response = Get("reports/recipients/count", parameters);
            return SerializationUtils<long>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns a page of click events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <param name="pageIndex">the index of the page</param>
        /// <param name="pageSize">the size of the page</param>
        /// <returns>a page of click events</returns>
        public Page<Click> GetClicks(ClickParameters options, int pageIndex, int pageSize)
        {
            QueryParameters parameters = CreatePageQueryParameters(pageIndex, pageSize, options);

            ResponseWrapper response = Get("reports/clicks", parameters);

            Page<Click> page = new Page<Click>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<ClickCollection>.FromXmlString(response.Body);

            return page;
        }

        /// <summary>
        /// Returns a page of unique click events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <param name="pageIndex">the index of the page</param>
        /// <param name="pageSize">the size of the page</param>
        /// <returns>a page of unqiue click events</returns>
        public Page<Click> GetClicksUnique(ClickParameters options, int pageIndex, int pageSize)
        {
            QueryParameters parameters = CreatePageQueryParameters(pageIndex, pageSize, options);

            ResponseWrapper response = Get("reports/clicks/unique", parameters);

            Page<Click> page = new Page<Click>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<ClickCollection>.FromXmlString(response.Body);

            return page;
        }

        /// <summary>
        /// Returns the number of click events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <returns>the number of click events</returns>
        public long GetClicksCount(ClickParameters options)
        {
            QueryParameters parameters = options.GetQueryParameters();
            ResponseWrapper response = Get("reports/clicks/count", parameters);
            return SerializationUtils<long>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns the number of unique click events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <returns>the number of unique click events</returns>
        public long GetClicksUniqueCount(ClickParameters options)
        {
            QueryParameters parameters = options.GetQueryParameters();
            ResponseWrapper response = Get("reports/clicks/unique/count", parameters);
            return SerializationUtils<long>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns a page of bounce events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <param name="pageIndex">the index of the page</param>
        /// <param name="pageSize">the size of the page</param>
        /// <returns>a page of bounce events</returns>
        public Page<Bounce> GetBounces(BounceParameters options, int pageIndex, int pageSize)
        {
            QueryParameters parameters = CreatePageQueryParameters(pageIndex, pageSize, options);

            ResponseWrapper response = Get("reports/bounces", parameters);
            Page<Bounce> page = new Page<Bounce>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<BounceCollection>.FromXmlString(response.Body);
            return page;
        }

        /// <summary>
        /// Returns the number of bounce events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <returns>the number of bounce events</returns>
        public long GetBouncesCount(BounceParameters options)
        {
            QueryParameters parameters = options.GetQueryParameters();
            ResponseWrapper response = Get("reports/bounces/count", parameters);
            return SerializationUtils<long>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns a page of unsubscription events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <param name="pageIndex">the index of the page</param>
        /// <param name="pageSize">the size of the page</param>
        /// <returns>a page of unsubscription events</returns>
        public Page<Unsubscription> GetUnsubscriptions(UnsubscriptionParameters options, int pageIndex, int pageSize)
        {
            QueryParameters parameters = CreatePageQueryParameters(pageIndex, pageSize, options);
            
            ResponseWrapper response = Get("reports/unsubscriptions", parameters);
            Page<Unsubscription> page = new Page<Unsubscription>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<UnsubscriptionCollection>.FromXmlString(response.Body);
            
            return page;
        }

        /// <summary>
        /// Returns the number of unsubscription events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <returns>the numbe rof unsubscription events</returns>
        public long GetUnsubscriptionsCount(UnsubscriptionParameters options)
        {
            QueryParameters parameters = options.GetQueryParameters();
            ResponseWrapper response = Get("reports/unsubscriptions/count", parameters);
            return SerializationUtils<long>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns a page of contacts that subscribed for the given account. The contacts can be filtered either by a date interval or one or a list of mailing IDs (DOI Mailings). Note that this only returns subscribers that were subscribed by a DOI mailing that was sent through Maileon.
        /// <param name="options">the options for this query</param>
        /// <param name="pageIndex">the index of the page</param>
        /// <param name="pageSize">the size of the page</param>
        /// <returns>a page of subscription events</returns>
        public Page<Subscriber> GetSubscribers(SubscriberParameters options, int pageIndex, int pageSize)
        {
            QueryParameters parameters = CreatePageQueryParameters(pageIndex, pageSize, options);

            ResponseWrapper response = Get("reports/subscribers", parameters);
            Page<Subscriber> page = new Page<Subscriber>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<SubscriberCollection>.FromXmlString(response.Body);
            
            return page;
        }

        /// <summary>
        /// Returns the number of subscription events based on the specified parameters
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <returns>the number of subscription events</returns>
        public long GetSubscribersCount(SubscriberParameters options)
        {
            QueryParameters parameters = options.GetQueryParameters();
            ResponseWrapper response = Get("reports/subscribers/count", parameters);
            return SerializationUtils<long>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns a page of block status changes. This can either be the contact has been blocked or unblocked. You can filter by the old and new status or you can get the number of block status changes only.
        /// <param name="options">the options for this query</param>
        /// <param name="pageIndex">the index of the page</param>
        /// <param name="pageSize">the size of the page</param>
        /// <returns>a page of block status change events</returns>
        public Page<Block> GetBlocks(BlockParameters options, int pageIndex, int pageSize)
        {
            QueryParameters parameters = CreatePageQueryParameters(pageIndex, pageSize, options);

            ResponseWrapper response = Get("reports/blocks", parameters);
            Page<Block> page = new Page<Block>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<BlockCollection>.FromXmlString(response.Body);

            return page;
        }

        /// <summary>
        /// Returns the number of block status changes
        /// </summary>
        /// <param name="options">the options for this query</param>
        /// <returns>the number of block status change events</returns>
        public long GetBlocksCount(BlockParameters options)
        {
            QueryParameters parameters = options.GetQueryParameters();
            ResponseWrapper response = Get("reports/blocks/count", parameters);
            return SerializationUtils<long>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Creates the query parameters for querying a page
        /// </summary>
        /// <param name="pageIndex">the index of the page</param>
        /// <param name="pageSize">the size of the page</param>
        /// <param name="parameters">the options for this query</param>
        /// <returns></returns>
        private QueryParameters CreatePageQueryParameters(int pageIndex, int pageSize, AbstractParameters options)
        {
            ValidatePaginationParameters(pageIndex, pageSize);

            QueryParameters parameters = options.GetQueryParameters();
            parameters.Add("page_index", pageIndex);
            parameters.Add("page_size", pageSize);

            return parameters;
        }
    }
}
