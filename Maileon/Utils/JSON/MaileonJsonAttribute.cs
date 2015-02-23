using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maileon.Utils.JSON
{
    public class MaileonJsonAttribute : Attribute
    {
        public string Name { get; set; }

        public MaileonJsonAttribute(string name)
        {
            this.Name = name;
        }
    }
}
