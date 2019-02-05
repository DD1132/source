using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddTrainee.xaml
    /// </summary>
    public partial class AddTrainee : Window
    {
        private static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        BE.Trainee trainee;
        public AddTrainee()
        {

            InitializeComponent();
            trainee = new BE.Trainee { DayOfBirth = new DateTime(2000, 1, 1), Address = new Address(), CarTrained = new CarType(), Name = new Name(), Instructor = new Name() };
            this.DataContext = trainee;
            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.carTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.carType));
            this.gearTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.GearType));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddTrainee(trainee);
            }
            catch (Exception x)
            {

                MessageBox.Show(x.ToString());
            }

        }
    }
}
