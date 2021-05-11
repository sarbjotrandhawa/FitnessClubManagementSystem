using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.Models
{
    public class Feedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]

        public int Id { get; set; }
        //
        [Required(ErrorMessage = "Please enter Full name")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters")]
        [DisplayName("Full Name")]

        public string FullName { get; set; }
        //
        [Required(ErrorMessage = "Please enter the User name")]
        [EmailAddress(ErrorMessage = "Please enter correct format of email")]
        [DisplayName("Email")]
        public string Email { get; set; }
        //
        [Required(ErrorMessage = "Please enter the User name")]
        [DisplayName("Message")]
        public string Message { get; set; }
        //
        [DisplayName("Added On")]
        public DateTime FeedbackDate { get; set; }
    }
}