using System;
using System.Collections.Generic;
using System.Text;

namespace RollingMachines.Entities
{
    public class Rent
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
        
        public int CarId { get; set; }
        public Car Car { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float PriceInPent { get; set; }

    }
}
