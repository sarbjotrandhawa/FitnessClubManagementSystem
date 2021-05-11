using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.Models
{
    public class UserLogin
    {
        [Key]
        [DisplayName("User ID")]
        public int userID { get; set; }

        [Required(ErrorMessage = "Please enter the User Name")]
        [StringLength(50, ErrorMessage = "User Name cannot be more than 50 characters")]
        [DisplayName("User Email")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Please enter the Password")]
        [StringLength(50, ErrorMessage = "Password cannot be more than 50 characters")]
        [DisplayName("Password")]
        public string password { get; set; }
    }
}