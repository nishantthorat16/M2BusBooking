using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M2BusBooking
{
    public class Vehicle
    {
        [Key]
        public string BusType { get; set; }
        public string OperatorName { get; set; }
        [Required (ErrorMessage ="Enter a valid number")]
        public int Vehicle_Number { get; set; }
        public bool IsAcCoach { get; set; }
        public bool IsSlepper { get; set; }
        public DateTime DateOfJourney { get; set; }
        public int MaxSeatsAvailable { get; set; }

    }
}
