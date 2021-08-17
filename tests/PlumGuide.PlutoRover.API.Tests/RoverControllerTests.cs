using System;
using FluentAssertions;
using NUnit.Framework;
using PlumGuide.PlutoRover.API.Exceptions;
using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API.Tests
{
    public class RoverControllerTests
    {
        [Test]
        [Description(@"GIVEN rover is at 0, 0, North
                       WHEN FFRFF command is issued
                       THEN rover is at 2, 2, East")]
        public void RoverExecuteCommandSuccessfully()
        {
            var position = new Position(0, 0);
            var plutoRover = new PlutoRover(position, new CardinalNorth());
            var planetGrid = new Grid {Height = 100, Width = 100};
            var controller = new RoverController(plutoRover, planetGrid);

            var expectedDirection = CardinalDirection.East;
            var expectedPosition = new Position(2, 2);

            controller.ExecuteCommand("FFRFF");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(expectedDirection);
            expectedRover.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North
                       WHEN FBLR command is issued
                       THEN rover is at 0, 0, North")]
        public void BackToStart()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 100, Width = 100 };
            var controller = new RoverController(plutoRover, planetGrid);

            var expectedDirection = CardinalDirection.North;
            var expectedPosition = new Position(0, 0);

            controller.ExecuteCommand("FBLR");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(expectedDirection);
            expectedRover.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North
                       WHEN F command is issued
                       THEN rover is at 0, 1, North")]
        public void OneFCommand()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 100, Width = 100 };
            var controller = new RoverController(plutoRover, planetGrid);

            var expectedDirection = CardinalDirection.North;
            var expectedPosition = new Position(0, 1);

            controller.ExecuteCommand("F");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(expectedDirection);
            expectedRover.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North on 10, 10 Grid
                       WHEN B command is issued
                       THEN rover is at 0, 9, North")]
        public void OneBCommand()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 10, Width = 10 };
            var controller = new RoverController(plutoRover, planetGrid);

            var expectedDirection = CardinalDirection.North;
            var expectedPosition = new Position(0, 9);

            controller.ExecuteCommand("B");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(expectedDirection);
            expectedRover.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North
                       WHEN L command is issued
                       THEN rover is at 0, 0, West")]
        public void OneLCommand()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 10, Width = 10 };
            var controller = new RoverController(plutoRover, planetGrid);

            var expectedDirection = CardinalDirection.West;
            var expectedPosition = new Position(0, 0);

            controller.ExecuteCommand("L");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(expectedDirection);
            expectedRover.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North
                       WHEN R command is issued
                       THEN rover is at 0, 0, East")]
        public void OneRCommand()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 10, Width = 10 };
            var controller = new RoverController(plutoRover, planetGrid);

            var expectedDirection = CardinalDirection.East;
            var expectedPosition = new Position(0, 0);

            controller.ExecuteCommand("R");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(expectedDirection);
            expectedRover.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North on 1, 1 Grid
                       WHEN FF command is issued
                       THEN rover wraps to 0, 0, North")]
        public void WrapYWhenMaxHeightExceeded()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 1, Width = 1 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("FF");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(CardinalDirection.North);
            expectedRover.Position.XCoordinate.Should().Be(0);
            expectedRover.Position.YCoordinate.Should().Be(0);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, South on 2, 2 Grid
                       WHEN F command is issued
                       THEN rover wraps to 0, 1, South")]
        public void WrapYWhenMinHeightExceeded()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalSouth());
            var planetGrid = new Grid { Height = 2, Width = 2 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("F");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(CardinalDirection.South);
            expectedRover.Position.XCoordinate.Should().Be(0);
            expectedRover.Position.YCoordinate.Should().Be(1);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, East on 1, 1 Grid
                       WHEN FF command is issued
                       THEN rover wraps to 0, 0, East")]
        public void WrapX()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalEast());
            var planetGrid = new Grid { Height = 1, Width = 1 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("FF");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(CardinalDirection.East);
            expectedRover.Position.XCoordinate.Should().Be(0);
            expectedRover.Position.YCoordinate.Should().Be(0);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, West on 2, 2 Grid
                       WHEN F command is issued
                       THEN rover wraps to 1, 0, East")]
        public void WrapXWest()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalWest());
            var planetGrid = new Grid { Height = 2, Width = 2 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("F");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(CardinalDirection.West);
            expectedRover.Position.XCoordinate.Should().Be(1);
            expectedRover.Position.YCoordinate.Should().Be(0);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, East on 10, 10 Grid
                       WHEN BB command is issued
                       THEN rover wraps to 8, 0, East")]
        public void WrapXBackward()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalEast());
            var planetGrid = new Grid { Height = 10, Width = 10 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("BB");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(CardinalDirection.East);
            expectedRover.Position.XCoordinate.Should().Be(8);
            expectedRover.Position.YCoordinate.Should().Be(0);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, West on 3, 3 Grid
                       WHEN BB command is issued
                       THEN rover wraps to 2, 0, West")]
        public void WrapXBackwardWest()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalWest());
            var planetGrid = new Grid { Height = 3, Width = 3 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("BB");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(CardinalDirection.West);
            expectedRover.Position.XCoordinate.Should().Be(2);
            expectedRover.Position.YCoordinate.Should().Be(0);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North on 10, 10 Grid
                       WHEN BB command is issued
                       THEN rover wraps to 0, 8, North")]
        public void WrapYBackward()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 10, Width = 10 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("BB");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(CardinalDirection.North);
            expectedRover.Position.XCoordinate.Should().Be(0);
            expectedRover.Position.YCoordinate.Should().Be(8);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, South on 3, 3 Grid
                       WHEN BB command is issued
                       THEN rover wraps to 0, 2, South")]
        public void WrapYBackwardWest()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalSouth());
            var planetGrid = new Grid { Height = 3, Width = 3 };
            var controller = new RoverController(plutoRover, planetGrid);

            controller.ExecuteCommand("BB");

            var expectedRover = controller.Rover;

            expectedRover.Cardinal.Direction.Should().Be(CardinalDirection.South);
            expectedRover.Position.XCoordinate.Should().Be(0);
            expectedRover.Position.YCoordinate.Should().Be(2);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North on 3, 3 Grid
                       AND an obstacle exist at 0, 1
                       WHEN F command is issued
                       THEN InvalidOperationException is thrown")]
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

        [Test]
        [Description(@"GIVEN rover is at 0, 0, East on 3, 3 Grid
                       AND an obstacle exist at 1, 0
                       WHEN F command is issued
                       THEN InvalidOperationException is thrown")]
        public void ObstacleX()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalEast());
            var planetGrid = new Grid { Height = 3, Width = 3 };
            planetGrid.AddObstacle(new Position(1, 0), "X1");
            var sut = new RoverController(plutoRover, planetGrid);

            Action action = () => sut.ExecuteCommand("F");

            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North
                       WHEN invalid G command is issued
                       THEN UnsupportedCommandException is thrown")]
        public void InvalidCommand()
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new PlutoRover(coordinate, new CardinalNorth());
            var planetGrid = new Grid { Height = 10, Width = 10 };
            var sut = new RoverController(plutoRover, planetGrid);

            Action action = () => sut.ExecuteCommand("G");

            action.Should().Throw<UnsupportedCommandException>();
        }
    }
}
