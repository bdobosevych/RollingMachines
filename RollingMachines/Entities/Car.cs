using System;
using System.Collections.Generic;
using System.Text;

namespace RollingMachines.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public int  Year { get; set; }

        public float PriceInHout  { get; set; }

        public string Loose { get; set; }

    }
}

