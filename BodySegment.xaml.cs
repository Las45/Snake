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

namespace Snake
{
    /// <summary>
    /// Interaktionslogik für BodySegment.xaml
    /// </summary>
    public partial class BodySegment : UserControl
    {
        private int x;
        private int y;

        public BodySegment(int x, int y)
        {
            InitializeComponent();
            this.x = x;
            this.y = y;
        }
        public (int, int) GetPosition()
        {
            return (this.x, this.y);
        }
    }
}
