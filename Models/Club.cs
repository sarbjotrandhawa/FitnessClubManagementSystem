using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.Models
{
    public class Club
    {
        [Key]
        [DisplayName("Club Id")]
        public int clubId { get; set; }

        [DisplayName("Club Address")]
        [Required(ErrorMessage = "Please enter Street Address")]
        [StringLength(100, ErrorMessage = "Address cannot be more than 50 characters")]
        public string clubStAddress { get; set; }

        [Required(ErrorMessage = "Please enter City name")]
        [StringLength(50, ErrorMessage = "City Name cannot be more than 50 characters")]
        [DisplayName("City")]
        public string clubCity { get; set; }
        [DisplayName("Province")]

        [Required(ErrorMessage = "Please enter Province name")]
        [StringLength(50, ErrorMessage = "Province Name cannot be more than 50 characters")]
        public string clubProvince { get; set; }

        [Required(ErrorMessage = "Please enter Postal Code")]
        [StringLength(50, ErrorMessage = "Postal code cannot be more than 50 characters")]
        [DisplayName("Postal Code")]
        public string clubPostal { get; set; }

    }
}