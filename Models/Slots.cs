using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.Models
{
    public class Slots
    {
        [Key]
        [DisplayName("Slot ID")]
        public int slotId { get; set; }
        [DisplayName("Customer ID")]
        public int customerId { get; set; }
        [DisplayName("Club ID")]
        public int clubId { get; set; }
        [DisplayName("Date")]
        public DateTime date { get; set; }
        [DisplayName("Slot detail")]
        public String slotTimeID { get; set; }
    }
}