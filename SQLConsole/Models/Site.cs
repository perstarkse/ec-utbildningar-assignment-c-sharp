using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConsole.Classes
{
    internal class Site
    {
        internal int Id { get; set; }
        internal string Name { get; set; } = string.Empty;
        internal Address Address { get; set; } = new Address();
    }
}
