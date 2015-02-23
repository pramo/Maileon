using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maileon.Utils.Serialization.Contacts;

namespace Maileon.Contacts
{
    public class SynchronizationError
    {
        public string Field { get; private set; }
        public string Message { get; private set; }
        public int Code { get; private set; }
        public string Description { get; private set; }

        internal SynchronizationError(XmlSynchronizationError error)
        {
            this.Field = error.Field;
            this.Message = error.Message;
            this.Code = error.Value;
            this.Description = error.Description;
        }
    }
}
