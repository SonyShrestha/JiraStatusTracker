using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JiraProgressTracker.Models
{
    public class Status
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]

        public String Name { get; set; }
    }
}