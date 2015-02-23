using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils;

namespace Maileon.Blacklists
{
    public class MaileonBlacklistsService : AbstractMaileonService
    {
        public static string SERVICE = "MAILEON BLACKLISTS";

        public MaileonBlacklistsService(MaileonConfiguration config) : base(config, SERVICE) { }

        /// <summary>
        /// Get a list of the blacklists defined in the account.
        /// </summary>
        /// <returns></returns>
        public List<Blacklist> GetBlacklists()
        {
            ResponseWrapper response = Get("blacklists");
            return SerializationUtils<BlacklistCollection>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Get an account-specific blacklist by its ID.
        /// </summary>
        /// <param name="blacklistId">The ID of the blacklist</param>
        /// <returns></returns>
        public Blacklist GetBlacklist(long blacklistId)
        {
            ResponseWrapper response = Get("blacklists/" + blacklistId.ToString());
            return SerializationUtils<Blacklist>.FromXmlString(response.Body);
        }

        /// <summary>
        /// Add a number of entries to an existing blacklist.
        /// </summary>
        /// <param name="blacklistId">The ID of the blacklist</param>
        /// <param name="entries">The entries to import</param>
        /// <param name="entries"></param>
        public void AddEntriesToBlacklist(long blacklistId, EntryCollection entries)
        {
            if (entries.Name == null)
            {
                throw new MaileonException("the entry collection must have a name");
            }

            Post("blacklists/" + blacklistId.ToString() + "/actions", SerializationUtils<EntryCollection>.ToXmlString(entries));
        }
    }
}
