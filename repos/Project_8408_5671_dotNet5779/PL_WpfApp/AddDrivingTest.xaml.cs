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
using BE;
using BL;

namespace PL_WpfApp
{
    /// <summary>
    /// Interaction logic for AddDrivingTest.xaml
    /// </summary>
    public partial class AddDrivingTest : Window
    {
        private static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        BE.DrivingTest drivingTest;
        public AddDrivingTest()
        {
            InitializeComponent();
            drivingTest = new BE.DrivingTest { Date = new DateTime(2000, 1, 1),  carType = new CarType(), requirements=new Requirements(),StartingPoint=new Address() };
            this.DataContext = drivingTest;
            this.carTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.carType));
            this.gearTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.GearType));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddDrivingTest(drivingTest);
            }
            catch (Exception x)
            {

                MessageBox.Show(x.ToString());
            }
        }
    }
}
