using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API
{
    public class PlutoRover : IRover
    {
        public Position Position { get; private set; }
        public ICardinal Cardinal { get; private set; }

        public PlutoRover(Position position, ICardinal cardinal)
        {
            Position = position;
            Cardinal = cardinal;
        }

        public void Forward()
        {
            if (Cardinal.Direction == CardinalDirection.East || Cardinal.Direction == CardinalDirection.West)
            {
                MoveHorizontally(1);
            }
            else
            {
                MoveVertically(1);
            }
        }

        public void Backward()
        {
            if (Cardinal.Direction == CardinalDirection.North || Cardinal.Direction == CardinalDirection.South)
            {
                MoveVertically(-1);
            }
            else
            {
                MoveHorizontally(-1);
            }
        }

        public void TurnLeft()
        {
            Cardinal = Cardinal.Left;
        }

        public void TurnRight()
        {
            Cardinal = Cardinal.Right;
        }

        private void MoveVertically(int distance)
        {
            var newYPosition = Position.YCoordinate + distance;
            Position = new Position(Position.XCoordinate, newYPosition);
        }

        private void MoveHorizontally(int distance)
        {
            var newXPosition = Position.XCoordinate + distance;
            Position = new Position(newXPosition, Position.YCoordinate);
        }
    }
}
