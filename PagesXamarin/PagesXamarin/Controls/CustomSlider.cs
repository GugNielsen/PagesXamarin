using System;
using Xamarin.Forms;

namespace PagesXamarin.Controls
{
    public class CustomSlider : Slider
    {
        private double _stepValue = 1;

        public CustomSlider()
        {
            ValueChanged += OnValueChanged;
        }

        ~CustomSlider()
        {
            ValueChanged -= OnValueChanged;
        }

        // Analise valor do slider e arredonda para permitir
        // apenas valores inteiros.
        private void OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / _stepValue);
            Value = newStep * _stepValue;
        }
    }
}
