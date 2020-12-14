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
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();
            info.Text = "Тема курсової проекту:" +
                "Написання програми для сервісу прокатних машин. З можливість орендувати машину, нараховувалася знижка для постійних клієнтів, нарахування штрафів(за несвоєчасне повернення машини, ...) можливість передивлятися фотографії машин  і їх характеристик... " +
                "Використання: WPF, Microsoft SQL Server і відповідні додаткові технологій   ";
        }

      
    }
}
