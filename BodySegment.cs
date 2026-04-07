using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class BodySegment
    {
        private int x;
        private int y;

        public BodySegment(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public (int, int) GetPosition()
        {
            return (this.x, this.y);
        }
    }
}
