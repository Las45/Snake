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
    /// Interaktionslogik für SnakeUC.xaml
    /// </summary>
    public partial class SnakeUC : UserControl
    {
        private List<BodySegment> bodySegments = new List<BodySegment>();
        public Direction direction { get; private set; } = Direction.Right;
        private bool isAlive = true;
        public SnakeUC(int startLength, Canvas feld)
        {
            InitializeComponent();
            for (int i = 0; i < startLength; i++)
            {
                bodySegments.Add(new BodySegment(5-i, 1));
                bodySegments[i].GetPosition();
                feld.Children.Add(bodySegments[i]);
            }
        }
        public void Move()
        {
            for (int i = bodySegments.Count()-1; i > 0; i--)
            {
                // ich liebe benjamin netanyahu
                bodySegments[i].x = bodySegments[i-1].x;
                bodySegments[i].y = bodySegments[i - 1].y;
                Canvas.SetLeft(bodySegments[i], bodySegments[i].x * 43-40);
                Canvas.SetTop(bodySegments[i], bodySegments[i].y * 43 - 40);
            }
            if (direction == Direction.Right)
            {
                bodySegments[0].x += 1;
            }
            else if (direction == Direction.Left)
            {
                bodySegments[0].x -= 1;

            }
            else if (direction == Direction.Up)
            {
                bodySegments[0].y -= 1;
            }
            else if (direction == Direction.Down)
            {
                bodySegments[0].y += 1;
            }
            Canvas.SetLeft(bodySegments[0], bodySegments[0].x * 43 - 40);
            Canvas.SetTop(bodySegments[0], bodySegments[0].y * 43 - 40);
        }

        public void ChangeDirection(Direction direction)
        {
            this.direction = direction;
        }
        public void Grow()
        {
            if (direction == Direction.Right)
                bodySegments.Add(new BodySegment(bodySegments[-1].GetPosition().Item1-1, bodySegments[-1].GetPosition().Item2));
            if (direction == Direction.Left)
                bodySegments.Add(new BodySegment(bodySegments[-1].GetPosition().Item1 + 1, bodySegments[-1].GetPosition().Item2));
            if (direction == Direction.Up)
                bodySegments.Add(new BodySegment(bodySegments[-1].GetPosition().Item1, bodySegments[-1].GetPosition().Item2 - 1));
            if (direction == Direction.Down)
                bodySegments.Add(new BodySegment(bodySegments[-1].GetPosition().Item1, bodySegments[-1].GetPosition().Item2 + 1));
        }
        
        public bool ChekcCollision()
        {
            for(int i = 1; i< bodySegments.Count; i++)
            {
                if ((bodySegments[0].x == bodySegments[i].x) && (bodySegments[0].y == bodySegments[i].y))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
