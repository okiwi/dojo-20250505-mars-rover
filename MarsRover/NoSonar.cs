using System.Drawing;

namespace MarsRover
{
    public class NoSonar : ISonar
    {
        public bool IsObstacle(Point position)
        {
            return false;
        }
    }
}