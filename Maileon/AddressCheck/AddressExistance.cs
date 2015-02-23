using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.AddressCheck
{
    public enum AddressExistance
    {
        NonExtistant = 0,
        Exists = 1,
        NotVerifiable = 2,
        TemporaryError = -1
    }
}
