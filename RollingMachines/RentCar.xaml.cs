using RollingMachines.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RollingMachines
{
    /// <summary>
    /// Interaction logic for RentCar.xaml
    /// </summary>
    public partial class RentCar : Window
    {
        private User user;
        private Car car;
        private RollingMachinesContext rollingMachinesContext;
        public RentCar()
        {
            InitializeComponent();
        }
        public RentCar(User user,Car car)
        {
            InitializeComponent();
            rollingMachinesContext = new RollingMachinesContext();
            producer.Text = car.Producer;
            model.Text = car.Model;
            year.Text = car.Year.ToString();
            price.Text = car.PriceInHout.ToString();
            this.car = car;
            this.user = user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rent rent = new Rent();
            //rent.Car = car;
            rent.CarId = car.Id;
            //rent.User = user;
            rent.UserId = user.Id;
            rent.StartDate= Convert.ToDateTime( StartDate.SelectedDate);
            rent.EndDate = Convert.ToDateTime(endDate.SelectedDate);
            var help = Convert.ToDateTime(endDate.SelectedDate) - Convert.ToDateTime(StartDate.SelectedDate);
            try
            {
                float priceInPent = help.Days * car.PriceInHout * (100 - Convert.ToInt32(promoCod.Text)) / 100;
                if (priceInPent >= 0)
                {
                    rent.PriceInPent = priceInPent;
                    rollingMachinesContext.Add<Rent>(rent);
                    rollingMachinesContext.SaveChanges();
                    this.Close();
                }
                else
                {
                    error.Text = "Error data";
                }
            }
            catch
            {
                error.Text = "Error dataTime";
            }
            
           
        }
    }
}
