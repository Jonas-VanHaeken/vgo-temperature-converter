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

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertToCelcius(object sender, RoutedEventArgs e)
        {
            var fahrenheit = double.Parse(textBoxFahrenheit.Text);
            var celsius = Math.Round((fahrenheit - 32) / 1.8,2);
            MessageBox.Show(this,celsius.ToString() + " °C","Celcius");
        }

        private void ConvertToFahrenheit(object sender, RoutedEventArgs e)
        {
            var celcius = double.Parse(textBoxCelcius.Text);
            var fahrenheit = Math.Round(celcius * 1.8 + 32,2);
            MessageBox.Show(this, fahrenheit.ToString() + "°F", "Fahrenheit");
        }
    }
}
