using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M2BusBooking
{
    public enum Status
    {
        Confirmed = 1,
        WaitingList,
        Canceled
    }

    public class BusBooking
    {
        [Key]
        public int BookingId { get; set; }
        public Vehicle vehicle { get; set; }
        public string Customer { get; set; }
        public Status status { get; set; }
    }
}
