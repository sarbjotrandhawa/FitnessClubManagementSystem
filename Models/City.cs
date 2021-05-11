using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.Models
{
    
    public class City
    {

        [Key]
        public string Title { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }
    }
}