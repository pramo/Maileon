using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maileon.AddressCheck
{
    public enum MailserverDiagnosis
    {
        Unknown = 0,
        Truthful = 1,
        AlwaysConfirms = 2,
        AlwaysDenies = 3,
        Error = 4
    }
}
