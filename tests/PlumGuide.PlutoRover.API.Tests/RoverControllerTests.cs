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
            var controller = new RoverController(plutoRover);

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
            var controller = new RoverController(plutoRover);

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
            var controller = new RoverController(plutoRover);

            controller.ExecuteCommand("L");

            var roverState = controller.Rover;

            roverState.Cardinal.Direction.Should().Be(CardinalDirection.West);
        }
    }
}
