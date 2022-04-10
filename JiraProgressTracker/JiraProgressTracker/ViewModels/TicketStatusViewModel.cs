using JiraProgressTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiraProgressTracker.ViewModels
{
    public class TicketStatusViewModel
    {
        public IEnumerable<Status> Status { get; set; }
        public IEnumerable<Priority> Priority { get; set; }
        public IEnumerable<TicketType> TicketType { get; set; }
        public Ticket Ticket { get; set; }
    }
}