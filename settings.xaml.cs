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

namespace Snake
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public int speed { get; private set; }
        public int fieldWidth { get; private set; }
        public int fieldHeight { get; private set; }
        public int initialLength { get; private set; }

        public bool ok = false;
        private bool loded = false;

        public Settings(int speed = 1, int width = 10, int height = 10, int length = 1)
        {
            InitializeComponent();
            SnakeLogger.logger.Information("Settings wurden initialisiert");
            this.speed = speed;
            this.fieldWidth = width;
            this.fieldHeight = height;
            this.initialLength = length;
            SnakeLogger.logger.Information($"Settings Werten wurden gesetzt: {speed},{width},{height},{length}");
        }
        public void Apply()
        {
            this.speed = (int)SpeedSlider.Value;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Apply();
            ok = true;
            SnakeLogger.logger.Information($"Settings wurden gändert: {this.speed},{this.fieldWidth},{this.fieldHeight},{this.initialLength}");
            Close();
        }

        private void abbButton_Click(object sender, RoutedEventArgs e)
        {
            SnakeLogger.logger.Debug("Settings wurden abgebrochen");
            Close();
        }

        private void SpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (loded == true)
                slidervalue.Content = (int)SpeedSlider.Value;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loded = true;
        }
    }
}
