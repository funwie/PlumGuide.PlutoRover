using System;
using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API.Commands
{
    public class MoveForwardCommand : ICommand
    {
        private readonly IRover _rover;

        public MoveForwardCommand(IRover rover)
        {
            _rover = rover ?? throw new ArgumentNullException(nameof(rover));
        }

        public bool CanExecute(Grid planetGrid)
        {
            var nextPoint = GetNextPoint(planetGrid);
            return GridIsAvailable(planetGrid) && WillRoverCollideWithObstacle(planetGrid, nextPoint);
        }

        public IRover Execute(Grid planetGrid)
        {
            var nextPoint = GetNextPoint(planetGrid);
            return _rover.Forward(nextPoint);
        }

        private int GetNextPoint(Grid planetGrid)
        {
            var maxDistanceToMove = 1;
            var roverXPosition = _rover.Position.XCoordinate;
            var roverYPosition = _rover.Position.YCoordinate;

            var nextPoint = _rover.Cardinal.Direction switch
            {
                CardinalDirection.North => roverYPosition + maxDistanceToMove,
                CardinalDirection.South => roverYPosition - maxDistanceToMove,
                CardinalDirection.East => roverXPosition + maxDistanceToMove,
                CardinalDirection.West => roverXPosition - maxDistanceToMove,
                _ => 0
            };

            return GetNextPointWrappedAroundGridEdge(nextPoint, planetGrid);
        }

        private int GetNextPointWrappedAroundGridEdge(int nextPoint, Grid planetGrid)
        {
            if (RoverIsMovingHorizontally)
            {
                if (nextPoint == planetGrid.Width)
                {
                    nextPoint = 0;
                }

                if (nextPoint < 0)
                {
                    nextPoint = planetGrid.Width - 1;
                }
            }
            else
            {
                if (nextPoint == planetGrid.Height)
                {
                    nextPoint = 0;
                }

                if (nextPoint < 0)
                {
                    nextPoint = planetGrid.Height - 1;
                }
            }
            return nextPoint;
        }

        private bool GridIsAvailable(Grid planetGrid)
        {
            return planetGrid != null && (planetGrid.Width > 0 || planetGrid.Height > 0);
        }

        private bool WillRoverCollideWithObstacle(Grid planetGrid, int nextPoint)
        {
            foreach (var gridObstacle in planetGrid.Obstacles)
            {
                if (RoverIsMovingHorizontally)
                {
                    if (nextPoint == gridObstacle.Position.XCoordinate)
                        return false;
                }
                else
                {
                    if (nextPoint == gridObstacle.Position.YCoordinate)
                        return false;
                }
            }

            return true;
        }

        private bool RoverIsMovingHorizontally => _rover.Cardinal.Direction == CardinalDirection.East ||
                                             _rover.Cardinal.Direction == CardinalDirection.West;
    }
}
