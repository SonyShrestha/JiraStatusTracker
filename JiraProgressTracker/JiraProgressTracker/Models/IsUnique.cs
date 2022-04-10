using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JiraProgressTracker.Models
{
    public class IsUnique: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticketPassed = (Ticket)validationContext.ObjectInstance;
            AppDbContext _context = new AppDbContext();
            var ticket = _context.Tickets.SingleOrDefault(c => c.TicketNumber == ticketPassed.TicketNumber);
            if (ticket == null){
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Ticket Number Already Exists !!!");
            }
             
        }
    }
}