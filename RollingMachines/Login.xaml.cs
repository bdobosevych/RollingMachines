using RollingMachines.Entities;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private RollingMachinesContext rollingMachinesContext;
        public Login()
        {
            InitializeComponent();
            rollingMachinesContext = new RollingMachinesContext();

        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            var res= rollingMachinesContext.GetUser(nikName.Text,password.Text);
            
            if (res.Count == 1)
            {
                BasicWindow basicWindow = new BasicWindow(res[0]);
                basicWindow.Show();
                this.Close();
            }
            else if (res.Count == 0)
            {
                error.Text = "Error in NikName or Password";
            }
            else
            {
                MessageBox.Show("Error data");
            }
        }

        private void nikName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
