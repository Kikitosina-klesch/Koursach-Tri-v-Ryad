using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Koursach_Tri_v_Ryad
{
    /// <summary>
    /// Логика взаимодействия для AddName.xaml
    /// </summary>
    public partial class AddName : Window
    {
        public AddName()
        {
            InitializeComponent();
        }

        //GameLogic GameLog;

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
