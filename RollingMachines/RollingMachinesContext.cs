﻿using Microsoft.EntityFrameworkCore;
using RollingMachines.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace RollingMachines
{
    
    public class RollingMachinesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rent> Rents { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=BDOBOSEVYCH-PC;Database=RollingMachines;Trusted_Connection=True;");
        }
        public async Task AddUser(User user)
        {
            this.Add<User>(user);
            await this.SaveChangesAsync();
        }

        public List<User> GetUser(string nikname, string password)
        {
            return this.Set<User>().Where(u => u.NikName == nikname && u.Password == password).ToList();
        }
        public List<User> GetUsers(string nikname)
        {
            return this.Set<User>().Where(u => u.NikName == nikname).ToList();
        }
        public async Task AddRent(Rent rent, Car car)
        {
            this.Add<Rent>(rent);
            this.SaveChanges();
            car.Loose = (Convert.ToInt32(car.Loose) - 1).ToString();
            this.Update<Car>(car);
            this.SaveChanges();
        }

        public void GetCars(DataGrid dataGrid)
        {
            dataGrid.ItemsSource = this.Set<Car>().Where(u => u.Loose != "0").ToList();
        }
        public void GetRentUser(DataGrid dataGrid,User user)
        {
            
            var res =   this.Rents.Join
                (this.Cars,
                   carId1 => carId1.CarId,
                   carId2 => carId2.Id,
                   (carId1, carId2) => new
                   {
                       CarProducer = carId2.Producer,
                       CarModel = carId2.Model,
                       UserId = carId1.UserId,
                       StartDate = carId1.StartDate,
                       EndDate = carId1.EndDate,
                       Price = carId1.PriceInPent
                   }


                ).Where(u => u.UserId == user.Id).ToList();
            dataGrid.ItemsSource = res;
            
        }

        


    }
}
