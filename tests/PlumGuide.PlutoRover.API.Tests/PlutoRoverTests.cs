using FluentAssertions;
using NUnit.Framework;
using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API.Tests
{
    public class PlutoRoverTests
    {
 
        [Test]
        [Description(@"WHEN rover is started at 0, 0, N
                       THEN rover is at 0, 0, N")]
        public void RoverAtSpecifiedPosition()
        {
            var cardinal = new CardinalNorth();
            var position = new Position(0, 0);
            var expectedDirection = CardinalDirection.North;

            var sut = new PlutoRover(position, cardinal);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(position);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North
                       WHEN rover is moved forward by one point
                       THEN rover is at 0, 1, North")]
        public void MoveForwardNorth()
        {
            var cardinal = new CardinalNorth();
            var position = new Position(0, 0);

            var expectedPosition = new Position(0, 1);
            var expectedDirection = CardinalDirection.North;

            var sut = new PlutoRover(position, cardinal);
            sut.Forward(1);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, South
                       WHEN rover is moved forward by one point
                       THEN rover is at 0, 1, South")]
        public void MoveForwardSouth()
        {
            var cardinal = new CardinalSouth();
            var position = new Position(0, 0);

            var expectedPosition = new Position(0, 1);
            var expectedDirection = CardinalDirection.South;

            var sut = new PlutoRover(position, cardinal);
            sut.Forward(1);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, East
                       WHEN rover is moved forward by one point
                       THEN rover is at 1, 0, East")]
        public void MoveForwardEast()
        {
            var cardinal = new CardinalEast();
            var position = new Position(0, 0);

            var expectedPosition = new Position(1, 0);
            var expectedDirection = CardinalDirection.East;

            var sut = new PlutoRover(position, cardinal);
            sut.Forward(1);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, West
                       WHEN rover is moved forward by one point
                       THEN rover is at 1, 0, West")]
        public void MoveForwardWest()
        {
            var cardinal = new CardinalWest();
            var position = new Position(0, 0);

            var expectedPosition = new Position(1, 0);
            var expectedDirection = CardinalDirection.West;

            var sut = new PlutoRover(position, cardinal);
            sut.Forward(1);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 1, 1, North
                       WHEN rover is moved backward by one point
                       THEN rover is at 1, 0, North")]
        public void MoveBackwardNorth()
        {
            var cardinal = new CardinalNorth();
            var position = new Position(1, 1);

            var expectedPosition = new Position(1, 0);
            var expectedDirection = CardinalDirection.North;

            var sut = new PlutoRover(position, cardinal);
            sut.Backward(0);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 1, 1, South
                       WHEN rover is moved backward by one point
                       THEN rover is at 1, 0, South")]
        public void MoveBackwardSouth()
        {
            var cardinal = new CardinalSouth();
            var position = new Position(1, 1);

            var expectedPosition = new Position(1, 0);
            var expectedDirection = CardinalDirection.South;

            var sut = new PlutoRover(position, cardinal);
            sut.Backward(0);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 1, 1, East
                       WHEN rover is moved backward by one point
                       THEN rover is at 0, 1, East")]
        public void MoveBackwardEast()
        {
            var cardinal = new CardinalEast();
            var position = new Position(1, 1);

            var expectedPosition = new Position(0, 1);
            var expectedDirection = CardinalDirection.East;

            var sut = new PlutoRover(position, cardinal);
            sut.Backward(0);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 1, 1, West
                       WHEN rover is moved backward by one point
                       THEN rover is at 0, 1, West")]
        public void MoveBackwardWest()
        {
            var cardinal = new CardinalWest();
            var position = new Position(1, 1);

            var expectedPosition = new Position(0, 1);
            var expectedDirection = CardinalDirection.West;

            var sut = new PlutoRover(position, cardinal);
            sut.Backward(0);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North
                       WHEN rover is turned right
                       THEN rover is at 0, 0, East")]
        public void TurnRightFromNorth()
        {
            var cardinal = new CardinalNorth();
            var position = new Position(0, 0);

            var expectedPosition = new Position(0, 0);
            var expectedDirection = CardinalDirection.East;

            var sut = new PlutoRover(position, cardinal);
            sut.Turn(cardinal.Right);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, East
                       WHEN rover is turned right
                       THEN rover is at 0, 0, South")]
        public void TurnRightFromEast()
        {
            var cardinal = new CardinalEast();
            var position = new Position(0, 0);

            var expectedPosition = new Position(0, 0);
            var expectedDirection = CardinalDirection.South;

            var sut = new PlutoRover(position, cardinal);
            sut.Turn(cardinal.Right);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, South
                       WHEN rover is turned right
                       THEN rover is at 0, 0, East")]
        public void TurnRightFromSouth()
        {
            var cardinal = new CardinalSouth();
            var position = new Position(0, 0);

            var expectedPosition = new Position(0, 0);
            var expectedDirection = CardinalDirection.West;

            var sut = new PlutoRover(position, cardinal);
            sut.Turn(cardinal.Right);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, West
                       WHEN rover is turned right
                       THEN rover is at 0, 0, North")]
        public void TurnRightFromWest()
        {
            var cardinal = new CardinalWest();
            var position = new Position(0, 0);

            var expectedPosition = new Position(0, 0);
            var expectedDirection = CardinalDirection.North;

            var sut = new PlutoRover(position, cardinal);
            sut.Turn(cardinal.Right);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, North
                       WHEN rover is turned left
                       THEN rover is at 0, 0, West")]
        public void TurnLeftFromNorth()
        {
            var cardinal = new CardinalNorth();
            var position = new Position(0, 0);

            var expectedPosition = new Position(0, 0);
            var expectedDirection = CardinalDirection.West;

            var sut = new PlutoRover(position, cardinal);
            sut.Turn(cardinal.Left);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, West
                       WHEN rover is turned left
                       THEN rover is at 0, 0, South")]
        public void TurnLeftFromWest()
        {
            var cardinal = new CardinalWest();
            var position = new Position(0, 0);

            var expectedPosition = new Position(0, 0);
            var expectedDirection = CardinalDirection.South;

            var sut = new PlutoRover(position, cardinal);
            sut.Turn(cardinal.Left);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, South
                       WHEN rover is turned left
                       THEN rover is at 0, 0, East")]
        public void TurnLeftFromSouth()
        {
            var cardinal = new CardinalSouth();
            var position = new Position(0, 0);

            var expectedPosition = new Position(0, 0);
            var expectedDirection = CardinalDirection.East;

            var sut = new PlutoRover(position, cardinal);
            sut.Turn(cardinal.Left);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at 0, 0, East
                       WHEN rover is turned left
                       THEN rover is at 0, 0, North")]
        public void TurnLeftFromEast()
        {
            var cardinal = new CardinalEast();
            var position = new Position(0, 0);

            var expectedPosition = new Position(0, 0);
            var expectedDirection = CardinalDirection.North;

            var sut = new PlutoRover(position, cardinal);
            sut.Turn(cardinal.Left);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Test]
        [Description(@"GIVEN rover is at at 0, 0, North
                       WHEN example command 'FFRFF' is applied
                       THEN rover is at 2, 2, East")]
        public void FfrffExample()
        {
            var cardinal = new CardinalNorth();
            var position = new Position(0, 0);

            var expectedPosition = new Position(2, 2);
            var expectedDirection = CardinalDirection.East;

            var sut = new PlutoRover(position, cardinal);
            sut.Forward(2);
            sut.Turn(cardinal.Right);
            sut.Forward(2);

            sut.Cardinal.Direction.Should().Be(expectedDirection);
            sut.Position.Should().BeEquivalentTo(expectedPosition);
        }
    }
}