using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Runtime.Serialization;

using Maileon.Utils;

namespace Maileon.Transactions
{
    public class MaileonTransactionsService : AbstractMaileonService
    {
        public static string SERVICE = "MAILEON TRANSACTIONS SERVICE";
    
        public MaileonTransactionsService(MaileonConfiguration config) : base(config, SERVICE) { }
    
        /// <summary>
        /// Returns the number of transaction types in this account
        /// </summary>
        /// <returns>the number of transaction types</returns>
        public int GetTransactionTypesCount() 
        {
            ResponseWrapper response = Get("transactions/types/count");
            return SerializationUtils<int>.FromXmlString(response.Body, "count");
        }

        /// <summary>
        /// Returns a page of transaction types in the account
        /// </summary>
        /// <param name="pageIndex">the index of the page</param>
        /// <param name="pageSize">the size of the page</param>
        /// <returns>a page of transaction types</returns>
        public Page<TransactionType> GetTransactionTypes(int pageIndex, int pageSize) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("page_index", pageIndex);
            parameters.Add("page_size", pageSize);

            ResponseWrapper response = Get("transactions/types", parameters);
            Page<TransactionType> page = new Page<TransactionType>(pageIndex, pageSize, response);
            page.Items = SerializationUtils<TransactionTypeCollection>.FromXmlString(response.Body);

            return page;
        }

        /// <summary>
        /// Creates a new transaction type
        /// </summary>
        /// <param name="type">the transaction type to create</param>
        public void CreateTransactionType(TransactionType type) 
        {
            Post("transactions/types", SerializationUtils<TransactionType>.ToXmlString(type));
        }

        /// <summary>
        /// Deletes the given transaction type
        /// </summary>
        /// <param name="id">the type id of the transaction to delete</param>
        public void DeleteTransactionType(long id) 
        {
            Delete("transactions/types/" + id.ToString());
        }

        /// <summary>
        /// Returns a transaction type by its id
        /// </summary>
        /// <param name="id">the type id</param>
        /// <returns>a transaction type</returns>
        public TransactionType GetTransactionType(long id) 
        {
            ResponseWrapper response = Get("transactions/types/" + id.ToString());
            return SerializationUtils<TransactionType>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Creates a transaction in the account
        /// </summary>
        /// <param name="transactions">the transactions to create</param>
        /// <param name="release">whether the transaction should be released instantly</param>
        /// <param name="ignoreInvalidTransactions">if set to false invalid contacts will throw exceptions</param>
        /// <returns>a transaction processing report</returns>
        public TransactionProcessingReport CreateTransaction(Transaction transaction, bool release, bool ignoreInvalidTransactions)
        {
            return CreateTransactions(new List<Transaction> { transaction }, release, ignoreInvalidTransactions).First();
        }

        /// <summary>
        /// Creates any number of transactions in the account
        /// </summary>
        /// <param name="transactions">the transactions to create</param>
        /// <param name="release">whether the transaction should be released instantly</param>
        /// <param name="ignoreInvalidTransactions">if set to false invalid contacts will throw exceptions</param>
        /// <returns>a list of transaction rpcessing reports</returns>
        public List<TransactionProcessingReport> CreateTransactions(List<Transaction> transactions, bool release, bool ignoreInvalidTransactions) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("release", release);
            parameters.Add("ignore_invalid_transactions", ignoreInvalidTransactions);

            ResponseWrapper response = Post("transactions", parameters, MAILEON_JSON_TYPE, SerializationUtils<List<Transaction>>.ToJsonString(transactions));

            return SerializationUtils<TransactionProcessingReports>.FromJsonString(response.Body);
        }

        /// <summary>
        /// Delete all transactions of a given type before a given date in the account. Any previously-released transactions will be ignored.
        /// </summary>
        /// <param name="typeId">the type id of the transaction</param>
        /// <param name="beforeTimestamp">the timestamp to compare against</param>
        public void DeleteTransactions(long typeId, Timestamp beforeTimestamp) 
        {
            QueryParameters parameters = new QueryParameters();
            parameters.Add("type_id", typeId);
            parameters.Add("before_timestamp", beforeTimestamp);
            Delete("transactions", parameters);
        }
    }
}
