using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.Models
{
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("Transaction ID")]
        public int transactionId { get; set; }
        [DisplayName("Amount")]
        public int amount { get; set; }

        [Required(ErrorMessage = "Please enter the Card details.")]
        [StringLength(16, ErrorMessage = "Please enter valid card details.")]
        [DisplayName("Card Number")]
        public String cardNumber { get; set; }

        [Required(ErrorMessage = "Please enter the card expiry date.")]
        [DisplayName("Expiry Date")]
        public DateTime expiryDate { get; set; }

        [Required(ErrorMessage = "Please enter CVV detail.")]
        [StringLength(3, ErrorMessage = "Please enter valid CVV details")]
        [DisplayName("CVV")]
        public String CVV { get; set; }
        [DisplayName("Customer ID")]
        public int customerId { get; set; }

        [DisplayName("Enrollment ID")]
        public int enrolementId { get; set; }

    }
}