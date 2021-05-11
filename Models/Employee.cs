using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int employeeID { get; set; }

        [Required(ErrorMessage = "Please enter Employee Name")]
        [StringLength(50, ErrorMessage = "Employee Name cannot be more than 50 characters")]
        [DisplayName("Employee Name")]
        public string employeeName { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Please enter correct format of email")]
        [DisplayName("Email")]
        public string email { get; set; }

        
        [DisplayName("Join Date")]
        public DateTime joinDate { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        [StringLength(10, ErrorMessage = "Phone Number cannot be more than 10 characters")]
        [DisplayName("Phone Number")]
        public string phoneNumber { get; set; }

        [DisplayName("Club ID")]
        public int clubId { get; set; }

        [DisplayName("Club ID")]
        public virtual Club club { get; set; }
       
    }
}