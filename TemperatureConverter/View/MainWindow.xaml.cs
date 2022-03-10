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

        private void ConvertFahrenheit(object sender, RoutedEventArgs e)
        {
            var fahrenheit = double.Parse(textBoxFahrenheit.Text);
            var celsius = Math.Round((fahrenheit - 32) / 1.8,2);
            var kelvin = Math.Round(celsius + 273.15, 2);
            textBoxCelsius.Text = celsius.ToString();
            textBoxKelvin.Text = kelvin.ToString();
        }

        private void ConvertCelsius(object sender, RoutedEventArgs e)
        {
            var celsius = double.Parse(textBoxCelsius.Text);
            var fahrenheit = Math.Round(celsius * 1.8 + 32,2);
            var kelvin = Math.Round(celsius + 273.15,2);
            textBoxFahrenheit.Text = fahrenheit.ToString();
            textBoxKelvin.Text = kelvin.ToString();
        }

        private void ConvertKelvin(object sender, RoutedEventArgs e)
        {
            var kelvin = double.Parse(textBoxKelvin.Text);
            var celsius = Math.Round(kelvin - 273.15,2);
            var fahrenheit = Math.Round(celsius * 1.8 + 32, 2);
           
            textBoxFahrenheit.Text = fahrenheit.ToString();
            textBoxCelsius.Text = celsius.ToString();
        }
    }
}
