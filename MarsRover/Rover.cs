using System.Drawing;

namespace MarsRover
{
    public class Rover
    {
        public Direction Direction { get; private set; }

        public Point Position { get; private set; }
        internal ISonar Sonar { get; }

        public Rover(Point position, Direction direction)
        {
            Direction = direction;
            Position = position;
            Sonar = new NoSonar();
        }

        public Rover(Point position, Direction direction, ISonar sonar)
        {
            Direction = direction;
            Position = position;
            Sonar = sonar;
        }

        public void Turn(Rotate rotation)
        {
            const uint nbDirections = 4;
            if (rotation == Rotate.Left)
            {
                this.Direction = (Direction)(((uint)this.Direction + nbDirections - 1) % nbDirections);
            } else
            {
                this.Direction = (Direction)(((uint)this.Direction + 1) % nbDirections);
            }
        }

        internal void Forward(int steps=1)
        {
            Size delta = new Size();
            switch (this.Direction)
            {
                case Direction.North:
                    delta = new Size(0, -1);
                    break;
                case Direction.South:
                    delta = new Size(0, +1);
                    break;
                case Direction.East:
                    delta = new Size(+1, 0);
                    break;
                case Direction.West:
                    delta = new Size(-1, 0);
                    break;
            }
            while(steps > 0)
            {
                if (Sonar.IsObstacle(this.Position + delta))
                {
                    break;
                }
                this.Position += delta;
                steps--;
            }

        }
    }
}