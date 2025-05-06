using System.Drawing;

namespace MarsRover
{
    internal class FakeSonar : ISonar
    {
        public bool ForceObstacle { get; internal set; }

        public bool IsObstacle(Point position)
        {
            return ForceObstacle;
        }
    }

    internal class FakeSonar2 : ISonar
    {
        public Point ObstaclePosition { get; internal set; }

        public bool IsObstacle(Point position)
        {
            return ObstaclePosition == position;
        }
    }
}