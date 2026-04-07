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
    /// Interaktionslogik für settings.xaml
    /// </summary>
    public partial class settings : Window
    {
        private int speed;
        private int fieldWidth;
        private int fieldHeight;
        private int initialLength;

        public settings(int speed, int width, int height, int length)
        {
            InitializeComponent();
            this.speed = speed;
            this.fieldWidth = width;
            this.fieldHeight = height;
            this.initialLength = length;
        }
        public void Apply()
        {

        }
    }
}
