using System.Drawing;

namespace MarsRover
{
    public interface ISonar
    {
        bool IsObstacle(Point position);
    }
}