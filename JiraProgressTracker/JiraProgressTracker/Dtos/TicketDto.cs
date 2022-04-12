using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JiraProgressTracker.Dtos
{
    public class TicketDto
    {
        public int Id { get; set; }
        [Index(nameof(TicketNumber), IsUnique = true)]

        public int TicketNumber { get; set; }
        [StringLength(255)]
        public String JiraLink { get; set; }
        [StringLength(255)]
        
        public String Assignee { get; set; }
        public Boolean IsSupportTicket { get; set; }
        public String Description { get; set; }
        public String Comments { get; set; }


        public int StatusId { get; set; }

        [DefaultValue(1)]
        public int PriorityId { get; set; }


        [DefaultValue(1)]
        public int TicketTypeId { get; set; }
    }
}