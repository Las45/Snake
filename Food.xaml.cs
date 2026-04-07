using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
    /// Interaktionslogik für Food.xaml
    /// </summary>
    public partial class Food : UserControl
    {
        private int x;
        private int y;
        private int fieldWith;
        private int fieldHeight;
        private Random random = new Random();
        public Food(int fieldWith, int fieldHeight)
        {
            InitializeComponent();
            this.fieldHeight = fieldHeight;
            this.fieldWith = fieldWith;
        }

        public void Respawn()
        {
            x = random.Next(1, fieldWith);
            y = random.Next(1, fieldHeight);
        }
        public (int, int) GetPosition()
        {
            return (x,y);
        }
    }
}
