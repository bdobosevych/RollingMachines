using RollingMachines.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// Interaction logic for BasicWindow.xaml
    /// </summary>
    public partial class BasicWindow : Window
    {
        private RollingMachinesContext rollingMachinesContext;
        private User user;

        public BasicWindow()
        {
            InitializeComponent();
        }
        public BasicWindow(User user)
        {
            this.user = user;
            InitializeComponent();
            rollingMachinesContext = new RollingMachinesContext();
            nikName.Text = user.NikName;
            firstname.Text = user.FirstName;
            surname.Text = user.SurName;
            phone.Text = user.Phone;
            rollingMachinesContext.GetCars(car);
            rollingMachinesContext.GetRentUser(myRent, user);
            
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (nikName.Text != user.NikName || firstname.Text != user.FirstName || surname.Text != user.SurName || phone.Text != user.Phone)
            {
                if (String.IsNullOrEmpty(nikName.Text) || String.IsNullOrEmpty(firstname.Text) || String.IsNullOrEmpty(surname.Text) || String.IsNullOrEmpty(phone.Text))
                {
                    MessageBox.Show("Error in empty cells cannot be", "Login");
                }
                else
                {
                    user.NikName = nikName.Text;
                    user.FirstName = user.FirstName;
                    user.SurName = surname.Text;
                    user.Phone = phone.Text;
                    rollingMachinesContext.Update<User>(user);
                    rollingMachinesContext.SaveChanges();


                }
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void car_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void car_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        Car car = (Car)dgr.Item;
                        RentCar rentCar = new RentCar(user,car,this);
                        rentCar.Show();


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void car_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
