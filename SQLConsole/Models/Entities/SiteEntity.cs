using SQLConsole.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConsole.Models.Entities
{
    internal class SiteEntity
    {
        internal int Id { get; set; }
        internal string Name { get; set; } = string.Empty;
        internal int AddressId { get; set; }
    }
}
