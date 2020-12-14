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
        private BasicWindow basicWindow;
       
        public RentCar()
        {
            InitializeComponent();
        }
        public RentCar(User user,Car car,BasicWindow basicWindow)
        {
            InitializeComponent();
            rollingMachinesContext = new RollingMachinesContext();
            producer.Text = car.Producer;
            model.Text = car.Model;
            year.Text = car.Year.ToString();
            price.Text = car.PriceInHout.ToString();
            this.car = car;
            this.user = user;
            this.basicWindow = basicWindow;
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
            var SdateTime= Convert.ToDateTime(StartDate.SelectedDate);
            var EdateTime = Convert.ToDateTime(endDate.SelectedDate);
            if (SdateTime != new DateTime() && EdateTime != new DateTime())
            {
                if (EdateTime >= SdateTime)
                {
                    var help = EdateTime - SdateTime;
                    float priceInPent = help.Days * car.PriceInHout;
                    if (!String.IsNullOrEmpty(promoCod.Text))
                    {
                        if (Convert.ToInt32(promoCod.Text) > 0 && Convert.ToInt32(promoCod.Text) < 100)
                        {
                            priceInPent *= (100 - Convert.ToInt32(promoCod.Text)) / 100;

                        }

                    }
                    rent.PriceInPent = priceInPent;

                    rollingMachinesContext.AddRent(rent, car);


                    rollingMachinesContext.GetCars(basicWindow.car);
                    rollingMachinesContext.GetRentUser(basicWindow.myRent, user);

                    this.Close();

                }
                else
                {
                    error.Text = "Error data";
                }
            }
            else
            {
                error.Text = "Error data";
            }
           
            
           
        }
    }
}
