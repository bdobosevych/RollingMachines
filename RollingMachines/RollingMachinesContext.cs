using Microsoft.EntityFrameworkCore;
using RollingMachines.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollingMachines
{
    public class RollingMachinesContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rent>  Rents{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=BDOBOSEVYCH-PC;Database=RollingMachines;Trusted_Connection=True;");
        }
    }
}
