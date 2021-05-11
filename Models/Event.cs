using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.Models
{
    public class Event
    {
        [Key]
        [DisplayName("ID")]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Please enter Subject")]
        [StringLength(50, ErrorMessage = "Subject cannot be more than 50 characters")]
        [DisplayName("Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter Description")]
        [StringLength(5000, ErrorMessage = "Description cannot be more than 50 characters")]
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Start")]
        public System.DateTime Start { get; set; }
        [DisplayName("End")]
        public Nullable<System.DateTime> End { get; set; }

        [Required(ErrorMessage = "Please enter Theme Color")]
        [StringLength(50, ErrorMessage = "Theme Color cannot be more than 50 characters")]
        [DisplayName("Theme Color")]
        public string ThemeColor { get; set; }

        [DisplayName("Full Day")]
        public bool IsFullDay { get; set; }
    }
}