using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils.JSON;

using System.Runtime.Serialization;

namespace Maileon.Transactions
{
    public class TransactionProcessingReportCollection
    {
        [MaileonJsonAttribute("reports")]
        public List<TransactionProcessingReport> Items { get; set; }

        public static implicit operator List<TransactionProcessingReport>(TransactionProcessingReportCollection r)
        {
            return r.Items;
        }

        public TransactionProcessingReportCollection() { }
    }
}
