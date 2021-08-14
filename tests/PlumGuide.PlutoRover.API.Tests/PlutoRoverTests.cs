using FluentAssertions;
using NUnit.Framework;
using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API.Tests
{
    public class PlutoRoverTests
    {
 
        [Test]
        [Description(@"WHEN rover is started with parameters
                       THEN rover is at expected position")]
        public void RoverAtSpecifiedPosition()
        {
            var cardinal = new CardinalNorth();
            var position = new Position(0, 0);

            var sut = new PlutoRover(position, cardinal);

            sut.Cardinal.Should().BeEquivalentTo(cardinal);
            sut.Position.Should().BeEquivalentTo(position);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North
                       WHEN rover is moved forward
                       THEN rover is at 0, 1, North")]
        public void MoveForwardY()
        {
            var cardinal = new CardinalNorth();
            var position = new Position(0, 0);

            var expectedPosition = new Position(0, 1);
            var expectedCardinal = CardinalDirection.North;

            var sut = new PlutoRover(position, cardinal);
            sut.Forward();

            sut.Cardinal.Direction.Should().Be(expectedCardinal);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, East
                       WHEN rover is moved forward
                       THEN rover is at 1, 0, East")]
        public void MoveForwardX()
        {
            var cardinal = new CardinalEast();
            var position = new Position(0, 0);

            var expectedPosition = new Position(1, 0);
            var expectedCardinal = CardinalDirection.East;

            var sut = new PlutoRover(position, cardinal);
            sut.Forward();

            sut.Cardinal.Direction.Should().Be(expectedCardinal);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 1, 1, North
                       WHEN rover is moved backward
                       THEN rover is at 1, 0, North")]
        public void MoveBackwardY()
        {
            var cardinal = new CardinalNorth();
            var position = new Position(1, 1);

            var expectedPosition = new Position(1, 0);
            var expectedCardinal = CardinalDirection.North;

            var sut = new PlutoRover(position, cardinal);
            sut.Backward();

            sut.Cardinal.Direction.Should().Be(expectedCardinal);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at at 1, 1, East
                       WHEN rover is moved backward
                       THEN rover is at 0, 1, East")]
        public void MoveBackwardX()
        {
            var cardinal = new CardinalEast();
            var position = new Position(1, 1);

            var expectedPosition = new Position(0, 1);
            var expectedCardinal = CardinalDirection.East;

            var sut = new PlutoRover(position, cardinal);
            sut.Backward();

            sut.Cardinal.Direction.Should().Be(expectedCardinal);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at at 0, 0, North
                       WHEN rover is turned right
                       THEN rover is at 0, 0, East")]
        public void TurnRight()
        {
            var cardinal = new CardinalNorth();
            var position = new Position(0, 0);

            var expectedPosition = new Position(0, 0);
            var expectedCardinal = CardinalDirection.East;

            var sut = new PlutoRover(position, cardinal);
            sut.TurnRight();

            sut.Cardinal.Direction.Should().Be(expectedCardinal);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at at 0, 0, North
                       WHEN example command 'FFRFF' is applied
                       THEN rover is at 2, 2, East")]
        public void Example()
        {
            var cardinal = new CardinalNorth();
            var position = new Position(0, 0);

            var expectedPosition = new Position(2, 2);
            var expectedCardinal = CardinalDirection.East;

            var sut = new PlutoRover(position, cardinal);
            sut.Forward();
            sut.Forward();
            sut.TurnRight();
            sut.Forward();
            sut.Forward();

            sut.Cardinal.Direction.Should().Be(expectedCardinal);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }
    }
}