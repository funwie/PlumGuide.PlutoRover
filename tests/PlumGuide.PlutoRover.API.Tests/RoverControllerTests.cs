using System;
using FluentAssertions;
using NUnit.Framework;
using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API.Tests
{
    public class RoverControllerTests
    {
        [Test]
        [Description(@"WHEN rover is started without parameters
                       THEN rover is at 0, 0, North")]
        public void RoverAtDefaultStart()
        {
            var position = new Position(0, 0);
            var plutoRover = new PlutoRover(position, new CardinalNorth());
            var planetGrid = new Grid {Height = 100, Width = 100};
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("FFRFF");

            var roverState = controller.Rover;

            roverState.Cardinal.Direction.Should().Be(CardinalDirection.East);
        }

        [Test]
        [Description(@"WHEN rover is started without parameters
                       THEN rover is at 0, 0, North")]
        public void Commands()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 100, Width = 100 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("FBLR");

            var roverState = controller.Rover;

            roverState.Cardinal.Direction.Should().Be(CardinalDirection.North);
        }

        [Test]
        [Description(@"WHEN rover is started without parameters
                       THEN rover is at 0, 0, North")]
        public void ONeCommands()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 100, Width = 100 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("L");

            var roverState = controller.Rover;

            roverState.Cardinal.Direction.Should().Be(CardinalDirection.West);
        }

        [Test]
        [Description(@"WHEN rover is started without parameters
                       THEN rover is at 0, 0, North")]
        public void WrapYWhenMaxHeightExceeded()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 1, Width = 1 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("FF");

            var roverState = controller.Rover;

            roverState.Cardinal.Direction.Should().Be(CardinalDirection.North);
            roverState.Position.XCoordinate.Should().Be(0);
            roverState.Position.YCoordinate.Should().Be(0);
        }

        [Test]
        [Description(@"WHEN rover is started without parameters
                       THEN rover is at 0, 0, North")]
        public void WrapYWhenMinHeightExceeded()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalSouth());
            var planetGrid = new Grid { Height = 2, Width = 2 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("F");

            var roverState = controller.Rover;

            roverState.Cardinal.Direction.Should().Be(CardinalDirection.South);
            roverState.Position.XCoordinate.Should().Be(0);
            roverState.Position.YCoordinate.Should().Be(1);
        }

        [Test]
        [Description(@"WHEN rover is started without parameters
                       THEN rover is at 0, 0, North")]
        public void WrapX()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalEast());
            var planetGrid = new Grid { Height = 1, Width = 1 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("FF");

            var roverState = controller.Rover;

            roverState.Cardinal.Direction.Should().Be(CardinalDirection.East);
            roverState.Position.XCoordinate.Should().Be(0);
            roverState.Position.YCoordinate.Should().Be(0);
        }

        [Test]
        [Description(@"WHEN rover is started without parameters
                       THEN rover is at 0, 0, North")]
        public void WrapXWest()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalWest());
            var planetGrid = new Grid { Height = 2, Width = 2 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("F");

            var roverState = controller.Rover;

            roverState.Cardinal.Direction.Should().Be(CardinalDirection.West);
            roverState.Position.XCoordinate.Should().Be(1);
            roverState.Position.YCoordinate.Should().Be(0);
        }

        [Test]
        [Description(@"WHEN rover is started without parameters
                       THEN rover is at 0, 0, North")]
        public void WrapXBackward()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalEast());
            var planetGrid = new Grid { Height = 10, Width = 10 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("BB");

            var roverState = controller.Rover;

            roverState.Cardinal.Direction.Should().Be(CardinalDirection.East);
            roverState.Position.XCoordinate.Should().Be(8);
            roverState.Position.YCoordinate.Should().Be(0);
        }

        [Test]
        [Description(@"WHEN rover is started without parameters
                       THEN rover is at 0, 0, North")]
        public void WrapXBackwardWest()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalWest());
            var planetGrid = new Grid { Height = 3, Width = 3 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("BB");

            var roverState = controller.Rover;

            roverState.Cardinal.Direction.Should().Be(CardinalDirection.West);
            roverState.Position.XCoordinate.Should().Be(2);
            roverState.Position.YCoordinate.Should().Be(0);
        }

        [Test]
        [Description(@"WHEN rover is started without parameters
                       THEN rover is at 0, 0, North")]
        public void WrapYBackward()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 10, Width = 10 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("BB");

            var roverState = controller.Rover;

            roverState.Cardinal.Direction.Should().Be(CardinalDirection.North);
            roverState.Position.XCoordinate.Should().Be(0);
            roverState.Position.YCoordinate.Should().Be(8);
        }

        [Test]
        [Description(@"WHEN rover is started without parameters
                       THEN rover is at 0, 0, North")]
        public void WrapYBackwardWest()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalSouth());
            var planetGrid = new Grid { Height = 3, Width = 3 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("BB");

            var roverState = controller.Rover;

            roverState.Cardinal.Direction.Should().Be(CardinalDirection.South);
            roverState.Position.XCoordinate.Should().Be(0);
            roverState.Position.YCoordinate.Should().Be(2);
        }

        [Test]
        [Description(@"WHEN rover is started without parameters
                       THEN rover is at 0, 0, North")]
        public void ObstacleY()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 3, Width = 3 };
            planetGrid.AddObstacle(new Position(0, 1), "Y1");
            var sut = new RoverController(plutoRover, planetGrid);

            Action action = () => sut.ExecuteCommand("F");

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
