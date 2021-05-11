using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.Models
{
    public class Enrollment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("Enrollment ID")]
        public int enrolementId { get; set; }

        [DisplayName("Package ID")]
        public int packageId { get; set; }

        [DisplayName("Number of Months")]
        public int numberofmonths { get; set; }
        [DisplayName("Club ID")]
        public int clubId { get; set; }

        [DisplayName("Customer ID")]
        public int customerId { get; set;}
        public virtual Club club { get; set; }
        public virtual MembershipPackages membershipPackages { get; set; }
    }
}