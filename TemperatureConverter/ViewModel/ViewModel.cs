using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class ConverterViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double temperatureInKelvin;

        public double TemperatureInKelvin
        {
            get
            {
                return temperatureInKelvin;
            }
            set
            {
                temperatureInKelvin = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TemperatureInKelvin)));

            }
        }

        public ConverterViewModel()
        {
            this.Kelvin = new TemperatureScaleViewModel(this, new KelvinTemperatureScale());
            this.Celsius = new TemperatureScaleViewModel(this, new CelciusTemperatureScale());
            this.Fahrenheit = new TemperatureScaleViewModel(this, new FahrenheitTemperatureScale());

        }

        public TemperatureScaleViewModel Kelvin { get; }
        public TemperatureScaleViewModel Celsius { get; }
        public TemperatureScaleViewModel Fahrenheit { get; }

        public IEnumerable<TemperatureScaleViewModel> Scales
        {
            get
            {
                yield return this.Celsius;
                yield return this.Fahrenheit;
                yield return this.Kelvin;
            }
        }
    }

    public class TemperatureScaleViewModel : INotifyPropertyChanged
    {
        private readonly ConverterViewModel parent;
        private readonly ITemperatureScale temperatureScale;

        public TemperatureScaleViewModel(ConverterViewModel parent, ITemperatureScale temperatureScale)
        {
            this.temperatureScale = temperatureScale;
            this.parent = parent;

            this.parent.PropertyChanged += (sender, args) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temperature)));
        }

        public string Name => temperatureScale.Name;

        public double Temperature {
            get
            {
                return temperatureScale.ConvertFromKelvin(parent.TemperatureInKelvin);
            }
            set
            { 
                parent.TemperatureInKelvin = temperatureScale.ConvertToKelvin(value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    } 
}
