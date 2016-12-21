using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maileon
{
    /// <summary>
    /// A class for wrapping Maileon response pages
    /// </summary>
    /// <typeparam name="T">the type of elements listed on this page</typeparam>
    public class Page<T>
    {
        /// <summary>
        /// The total number of items
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// The index of this page
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// Number of items on this page
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Number of pages
        /// </summary>
        public int CountPages { get; set; }
        /// <summary>
        /// The items contained on this page
        /// </summary>
        public List<T> Items { get; set; }

        /// <summary>
        /// Create a new page with the given parameters
        /// </summary>
        /// <param name="totalItems">total number of items</param>
        /// <param name="pageIndex">index of this page</param>
        /// <param name="pageSize">number of items on this page</param>
        /// <param name="countPages">number of pages</param>
        public Page(int pageIndex, int pageSize, int countPages, int totalItems)
        {
            this.Items = new List<T>();
            this.PageIndex = (pageIndex <= countPages) ? pageIndex : countPages;
            this.PageSize = pageSize;
            this.CountPages = countPages;
            this.TotalItems = totalItems;
        }

        public Page() { }


        /// <summary>
        /// This method generates a page object with the given parameters from a response object.
        /// </summary>
        /// <param name="pageIndex">The index of the page (starting from 1)</param>
        /// <param name="pageSize">The size of the page (elements on each page)</param>
        /// <param name="response">The response from the webservice that is parsed for X-Items and X-Pages to generate the new page</param>
        /// <returns>a Page</returns>
        internal Page(int pageIndex, int pageSize, ResponseWrapper response) : this(pageIndex, pageSize, int.Parse(response.Headers.GetValues("X-Pages").First()), int.Parse(response.Headers.GetValues("X-Items").First())) { }
    }
}
