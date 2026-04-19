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
        public int x;
        public int y;
        public int fieldWith;
        public int fieldHeight;
        private List<BodySegment> segnemts = new List<BodySegment>();
        private Random random = new Random();
        public Food(int fieldWith, int fieldHeight, Canvas field, List<BodySegment> segnemts)
        {
            InitializeComponent();
            this.fieldHeight = fieldHeight;
            this.fieldWith = fieldWith;
            this.segnemts=segnemts;
            x = random.Next(1, fieldWith);
            y = random.Next(1, fieldHeight);
            Canvas.SetLeft(this, x * 43 - 40);
            Canvas.SetTop(this, y * 43 - 40);
            field.Children.Add(this);
        }

        public void Respawn(Canvas field)
        {
            x = random.Next(1, fieldWith);
            y = random.Next(1, fieldHeight);
            bool a = true;
            while (a){
                for (int i = 0; i < segnemts.Count - 1; i++)
                {
                    if ((segnemts[i].x == x) && (segnemts[i].y == y))
                    {
                        x = random.Next(1, fieldWith);
                        y = random.Next(1, fieldHeight);
                        continue;
                    }
                }
                a=false;
            }
            Canvas.SetLeft(this, x * 43 - 40);
            Canvas.SetTop(this, y * 43 - 40);
            SnakeLogger.logger.Information($"Apfel wurde auf {x * 43 - 40},{y * 43 - 40} gesetzt");
        }
        public (int, int) GetPosition()
        {
            return (x,y);
        }
    }
}
