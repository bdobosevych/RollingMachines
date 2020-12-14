using System;
using System.Collections.Generic;
using System.Text;

namespace RollingMachines.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string NikName { get; set; }

        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }

        public string Password { get; set; }
    }
}
