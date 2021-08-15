using FluentAssertions;
using NUnit.Framework;
using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API.Tests
{
    public class CardinalDirectionsTests
    {
        [Test]
        [Description(@"GIVEN direction is facing North
                       WHEN direction is switch to left
                       THEN new direction is West")]
        public void LeftOfNorth()
        {
            var expectedDirection = CardinalDirection.West;

            var sut = new CardinalNorth();

            var actual = sut.Left;
            actual.Direction.Should().Be(expectedDirection);
        }

        [Test]
        [Description(@"GIVEN direction is facing North
                       WHEN direction is switch to right
                       THEN new direction is East")]
        public void RightOfNorth()
        {
            var expectedDirection = CardinalDirection.East;

            var sut = new CardinalNorth();

            var actual = sut.Right;
            actual.Direction.Should().Be(expectedDirection);
        }

        [Test]
        [Description(@"GIVEN direction is facing South
                       WHEN direction is switch to left
                       THEN new direction is East")]
        public void LeftOfSouth()
        {
            var expectedDirection = CardinalDirection.East;

            var sut = new CardinalSouth();

            var actual = sut.Left;
            actual.Direction.Should().Be(expectedDirection);
        }

        [Test]
        [Description(@"GIVEN direction is facing South
                       WHEN direction is switch to right
                       THEN new direction is West")]
        public void RightOfSouth()
        {
            var expectedDirection = CardinalDirection.West;

            var sut = new CardinalSouth();

            var actual = sut.Right;
            actual.Direction.Should().Be(expectedDirection);
        }

        [Test]
        [Description(@"GIVEN direction is facing East
                       WHEN direction is switch to left
                       THEN new direction is North")]
        public void LeftOfEast()
        {
            var expectedDirection = CardinalDirection.North;

            var sut = new CardinalEast();

            var actual = sut.Left;
            actual.Direction.Should().Be(expectedDirection);
        }

        [Test]
        [Description(@"GIVEN direction is facing East
                       WHEN direction is switch to right
                       THEN new direction is South")]
        public void RightOfEast()
        {
            var expectedDirection = CardinalDirection.South;

            var sut = new CardinalEast();

            var actual = sut.Right;
            actual.Direction.Should().Be(expectedDirection);
        }

        [Test]
        [Description(@"GIVEN direction is facing West
                       WHEN direction is switch to left
                       THEN new direction is South")]
        public void LeftOfWest()
        {
            var expectedDirection = CardinalDirection.South;

            var sut = new CardinalWest();

            var actual = sut.Left;
            actual.Direction.Should().Be(expectedDirection);
        }

        [Test]
        [Description(@"GIVEN direction is facing West
                       WHEN direction is switch to right
                       THEN new direction is North")]
        public void RightOfWest()
        {
            var expectedDirection = CardinalDirection.North;

            var sut = new CardinalWest();

            var actual = sut.Right;
            actual.Direction.Should().Be(expectedDirection);
        }
    }
}
