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
            info.Text = "Це програмне забезпечення для майбутньої компанії Dobby Com. яка буде займатися орендою машиш на довгі час. " +
                "Ви можете в прорамі зареєструватися або зайти вже існуючим профілем. Маєте можливість рендувати особисті дані а також перегляд машик які ви до того орендували і орендувати машину." +
                 "\nЯкщо є якісь питання дзвоніть за номером +380999065376"+
                    "\n Використання: WPF, Microsoft SQL Server і відповідні додаткові технологій   ";
        }

      
    }
}
