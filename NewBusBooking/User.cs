using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M2BusBooking
{
    public class User
    {
        [Key]
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        

    }
}
