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
        private Direction direction = Direction.Right;
        private bool isAlive = true;
        public SnakeUC(int startLength)
        {
            InitializeComponent();
            for (int i = 0; i < startLength; i++)
            {
                bodySegments.Add(new BodySegment(5-i, 1));
            }
        }
        public void Move()
        {

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
            //if (direction == Direction.Right)
            //    return true;
            //if (direction == Direction.Left)
            //    return true;
            //if (direction == Direction.Up)
            //    return true;
            //if (direction == Direction.Down)
            //    return true;
            return false;
        }
    }
}
