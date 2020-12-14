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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private RollingMachinesContext rollingMachinesContext;
        public Registration()
        {
            InitializeComponent();
            rollingMachinesContext = new RollingMachinesContext();
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            if (password1.Text != password2.Text)
            {
                error.Text = "Error Password not the Same";
            }
            else
            {
                if ((String.IsNullOrEmpty(nikname.Text) || String.IsNullOrEmpty(firstname.Text) || String.IsNullOrEmpty(surname.Text) || String.IsNullOrEmpty(phone.Text) || String.IsNullOrEmpty(password1.Text)))
                {
                    error.Text = "Error in empty cells cannot be";
                }
                else {
                    User user = new User();
                    user.NikName = nikname.Text;
                    user.FirstName = firstname.Text;
                    user.SurName = surname.Text;
                    user.Phone = phone.Text;
                    user.Password = password1.Text;
                    rollingMachinesContext.AddUser(user);
                   
                    BasicWindow basicWindow = new BasicWindow(user);
                    basicWindow.Show();
                    this.Close();

                }
            }
        }
    }
}
