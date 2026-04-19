using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Snake
{
    public class SnakeUC
    {
        public List<BodySegment> bodySegments = new List<BodySegment>();
        public Direction direction { get; private set; } = Direction.Right;
        private bool isAlive = true;
        public SnakeUC(int startLength, Canvas feld)
        {
            for (int i = 0; i < startLength; i++)
            {
                bodySegments.Add(new BodySegment(5 - i, 1));
                bodySegments[i].GetPosition();
                feld.Children.Add(bodySegments[i]);
            }
        }
        public void Move()
        {
            for (int i = bodySegments.Count() - 1; i > 0; i--)
            {
                bodySegments[i].x = bodySegments[i - 1].x;
                bodySegments[i].y = bodySegments[i - 1].y;
                Canvas.SetLeft(bodySegments[i], bodySegments[i].x * 43 - 40);
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
        public void Grow(Canvas feld)
        {
            bodySegments.Add(new BodySegment(bodySegments[bodySegments.Count - 1].GetPosition().Item1, bodySegments[bodySegments.Count - 1].GetPosition().Item2 + 1));
            Canvas.SetLeft(bodySegments[bodySegments.Count - 1], bodySegments[bodySegments.Count - 1].x * 43 - 40);
            Canvas.SetTop(bodySegments[bodySegments.Count - 1], bodySegments[bodySegments.Count - 1].y * 43 - 40);
            feld.Children.Add(bodySegments[bodySegments.Count - 1]);
        }

        public (bool, bool) ChekcCollision(int height, double width, (int, int) food_coords)
        {
            for (int i = 1; i < bodySegments.Count; i++)
            {
                if ((bodySegments[0].x == bodySegments[i].x) && (bodySegments[0].y == bodySegments[i].y))
                {
                    return (true, false);
                }
            }
            if ((bodySegments[0].x > width || bodySegments[0].x <= 0) || (bodySegments[0].y > height || bodySegments[0].y <= 0))
            {
                return (true, false);
            }
            else if ((bodySegments[0].x, bodySegments[0].y) == food_coords)
            {
                return (false, true);
            }
            return (false, false);
        }
    }
}
