using SQLConsole.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConsole.Models.Entities
{
    internal class TicketEntity
    {
        internal int Id { get; set; }
        internal DateTime CreatedAt { get; set; } = DateTime.Now;
        internal string Description { get; set; } = string.Empty;
        internal int StatusId { get; set; }
        internal int HandlerId { get; set; }
        internal int UserId { get; set; } 
    }
}
