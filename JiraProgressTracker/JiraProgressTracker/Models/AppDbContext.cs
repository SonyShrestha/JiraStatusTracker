using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JiraProgressTracker.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<TicketType> TicketType { get; set; }
    }
}