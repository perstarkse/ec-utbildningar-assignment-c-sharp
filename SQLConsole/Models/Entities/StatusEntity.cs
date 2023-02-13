using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConsole.Models.Entities
{
    internal class StatusEntity
    {
        internal int Id { get; set; }
        internal string StatusDescription { get; set; } = string.Empty;
        internal bool Finalized { get; set; } = false;
    }
}
