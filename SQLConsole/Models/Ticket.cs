using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConsole.Classes
{
    internal class Ticket
    {
        internal int Id { get; set; }
        internal DateTime CreatedAt { get; set; } = DateTime.Now;
        internal string Description { get; set; } = string.Empty;
        internal Status Status { get; set; } = null!;
        internal Handler Handler { get; set; } = null!;
        internal User User { get; set; } = null!;

    }
}
