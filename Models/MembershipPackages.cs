using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.Models
{
    public class MembershipPackages
    {

        [Key]
        [DisplayName("ID")]
        public int packageId { get; set; }

        [Required(ErrorMessage = "Please enter the Package Name")]
        [StringLength(50, ErrorMessage = "Package Name cannot be more than 50 characters")]
        [DisplayName("Package Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Please enter the Description")]
        [StringLength(1000, ErrorMessage = "Description cannot be more than 50 characters")]
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Price")]
        public int price { get; set; }
    }
}