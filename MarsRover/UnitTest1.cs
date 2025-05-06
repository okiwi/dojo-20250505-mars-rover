using System.ComponentModel;
using System.Drawing;

namespace MarsRover
{
    public class UnitTest1
    {
        [Fact]
        public void Constructor_Rover_DirectionNorth()
        {
            Point position = new Point(3,2);
            Rover rover = new Rover(position, Direction.North);

            Assert.Equal(Direction.North, rover.Direction);
            Assert.Equal(position, rover.Position);
        }

        [Fact]
        public void TurnLeft_Rover_DirectionNorth()
        {
            Point position = new Point(3, 2);
            Rover rover = new Rover(position, Direction.North);
            rover.Turn(Rotate.Left);

            Assert.Equal(Direction.West, rover.Direction);
            Assert.Equal(position, rover.Position);
        }

        [Fact]
        public void UTurn_Left_Rover_DirectionNorth()
        {
            Point position = new Point(3, 2);
            Rover rover = new Rover(position, Direction.North);
            rover.Turn(Rotate.Left);
            rover.Turn(Rotate.Left);


            Assert.Equal(Direction.South, rover.Direction);
            Assert.Equal(position, rover.Position);
        }

        [Fact]
        public void Three_Left_Rover_DirectionNorth()
        {
            Point position = new Point(3, 2);
            Rover rover = new Rover(position, Direction.North);
            rover.Turn(Rotate.Left);
            rover.Turn(Rotate.Left);
            rover.Turn(Rotate.Left);

            Assert.Equal(Direction.East, rover.Direction);
            Assert.Equal(position, rover.Position);
        }

        [Fact]
        public void Four_Left_Rover_DirectionNorth()
        {
            Point position = new Point(3, 2);
            Rover rover = new Rover(position, Direction.North);
            rover.Turn(Rotate.Left);
            rover.Turn(Rotate.Left);
            rover.Turn(Rotate.Left);
            rover.Turn(Rotate.Left);


            Assert.Equal(Direction.North, rover.Direction);
            Assert.Equal(position, rover.Position);
        }

        [Fact]
        public void TurnRight_Rover_DirectionNorth()
        {
            Point position = new Point(3, 2);
            Rover rover = new Rover(position, Direction.North);
            rover.Turn(Rotate.Right);

            Assert.Equal(Direction.East, rover.Direction);
            Assert.Equal(position, rover.Position);
        }

        [Fact]
        public void MoveForward_One_Rover_DirectionNorth()
        {
            Point position = new Point(3, 2);
            Rover rover = new Rover(position, Direction.North);

            rover.Forward();

            Assert.Equal(Direction.North, rover.Direction);
            Assert.Equal(new Point(3, 1), rover.Position);
        }

        [Fact]
        public void MoveForward_Three_Rover_DirectionNorth()
        {
            Point position = new Point(3, 2);
            Rover rover = new Rover(position, Direction.South);

            rover.Forward(3);

            Assert.Equal(Direction.South, rover.Direction);
            Assert.Equal(new Point(3, 5), rover.Position);
        }

        [Fact]
        public void MoveForward_Two_Rover_DirectionNorth()
        {
            Point position = new Point(3, 2);
            Rover rover = new Rover(position, Direction.East);

            rover.Forward(2);

            Assert.Equal(Direction.East, rover.Direction);
            Assert.Equal(new Point(5, 2), rover.Position);
        }

        [Fact]
        public void MoveForwardWithObstacle()
        {
            Point position = new Point(3, 2);
            Point destination = new Point(4, 2);

            FakeSonar sonar = new FakeSonar();
            sonar.ForceObstacle = true;

            Assert.True(sonar.IsObstacle(destination));
            Rover rover = new Rover(position, Direction.East, sonar);

            rover.Forward();
            Assert.Equal(Direction.East, rover.Direction);
            Assert.Equal(position, rover.Position);
        }

        [Fact]
        public void MoveForwardWithObstacleAtTwoSteps()
        {
            Point position = new Point(3, 2);
            Point destination = new Point(5, 2);

            FakeSonar2 sonar = new FakeSonar2();
            sonar.ObstaclePosition = destination;

            Assert.True(sonar.IsObstacle(destination));
            Rover rover = new Rover(position, Direction.East, sonar);

            rover.Forward(2);
            Assert.Equal(Direction.East, rover.Direction);
            Assert.Equal(new Point (4, 2), rover.Position);
        }
    }
}