using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.Models
{
    public class Customer
    {
        [Key]
        [DisplayName("Customer Id")]
        public int customerId { get; set; }

        [Required(ErrorMessage = "Please enter Customer Name")]
        [StringLength(50, ErrorMessage = "Customer Name cannot be more than 50 characters")]
        [DisplayName("Customer Name")]
        public String customerName { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        [StringLength(50, ErrorMessage = "Password cannot be more than 50 characters")]
        [DisplayName("Password")]
        public String password { get; set; }

        [Required(ErrorMessage = "Please enter Customer Email.")]
        [EmailAddress(ErrorMessage = "Please enter correct format of email")]
        [DisplayName("Customer Email")]
        public string customerEmail { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number.")]
        [StringLength(10, ErrorMessage = "Phone Number cannot be more than 10 characters")]
        [DisplayName("Customer Phone")]
        public String customerphone { get; set; }

        [Required(ErrorMessage = "Please enter Customer Address.")]
        [StringLength(50, ErrorMessage = "Customer Address cannot be more than 50 characters")]
        [DisplayName("Customer Address")]
        public String customerAddress { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime dateofbirth { get; set; }


    }
}