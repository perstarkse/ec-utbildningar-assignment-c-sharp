using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConsole.Models.Entities
{
    internal class UserEntity
    {
        internal int Id { get; set; }
        internal string FullName { get; set; } = string.Empty;
    }
}
