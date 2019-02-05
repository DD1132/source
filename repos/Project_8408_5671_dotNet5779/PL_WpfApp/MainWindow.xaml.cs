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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        public MainWindow()
        {
            InitializeComponent();
            SetVis();
        }
        private void SetVis()
        {
            DrivingTest.Visibility = Visibility.Hidden;
            Tester.Visibility = Visibility.Hidden;
            Trainee.Visibility = Visibility.Hidden;
        }

        private void Tester_button_Click(object sender, RoutedEventArgs e)
        {
            SetVis();
            Tester.Visibility = Visibility.Visible;
            //Window TesterWindow = new TesterWindow();
            //TesterWindow.Show();
        }

        private void Trainee_button_Click(object sender, RoutedEventArgs e)
        {
            SetVis();
            Trainee.Visibility = Visibility.Visible;
            //    Window TraineeWindow = new TraineeWindow();
            //    TraineeWindow.Show();
        }

        private void Driving_test_button_Click(object sender, RoutedEventArgs e)
        {
            SetVis();
            DrivingTest.Visibility = Visibility.Visible;
            //Window DrivingTestWindow = new DrivingTestWindow();
            //DrivingTestWindow.Show();
        }

     
    }
}
