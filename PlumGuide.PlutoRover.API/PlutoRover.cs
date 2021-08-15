using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API
{
    public class PlutoRover : IRover
    {
        public Position Position { get; }
        public ICardinal Cardinal { get; }

        public PlutoRover(Position position, ICardinal cardinal)
        {
            Position = position;
            Cardinal = cardinal;
        }

        public IRover Forward(int toPoint)
        {
            return RoverIsMovingHorizontally ? MoveHorizontally(toPoint) : MoveVertically(toPoint);
        }

        public IRover Backward(int toPoint)
        {
            return RoverIsMovingHorizontally ? MoveHorizontally(toPoint) : MoveVertically(toPoint);
        }

        public IRover Turn(ICardinal cardinal)
        {
            return new PlutoRover(Position, cardinal);
        }

        private IRover MoveVertically(int nextYPoint)
        {
            var newPosition = new Position(Position.XCoordinate, nextYPoint);
            return new PlutoRover(newPosition, Cardinal);
        }

        private IRover MoveHorizontally(int nextXPoint)
        {
            var newPosition = new Position(nextXPoint, Position.YCoordinate);
            return new PlutoRover(newPosition, Cardinal);
        }

        private bool RoverIsMovingHorizontally => Cardinal.Direction == CardinalDirection.East || 
                                                  Cardinal.Direction == CardinalDirection.West;
    }
}
