using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConsole.Models.Entities
{
    internal class AddressEntity
    {
        internal int Id { get; set; }
        internal string AddressField { get; set; } = string.Empty;
        internal string City { get; set; } = string.Empty;
        internal string ZipCode { get; set; } = string.Empty;
    }
}
