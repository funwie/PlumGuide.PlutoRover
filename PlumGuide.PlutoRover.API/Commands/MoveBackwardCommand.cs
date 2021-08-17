using System;
using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API.Commands
{
    public class MoveBackwardCommand : ICommand
    {
        public bool CanExecute(Grid planetGrid, IRover rover)
        {
            var nextPoint = GetNextPoint(planetGrid, rover);
            return GridIsAvailable(planetGrid) && WillRoverCollideWithObstacle(planetGrid, nextPoint, rover);
        }

        public IRover Execute(Grid planetGrid, IRover rover)
        {
            if (planetGrid is null) throw new ArgumentNullException(nameof(planetGrid));
            if (rover is null) throw new ArgumentNullException(nameof(rover));

            var nextPoint = GetNextPoint(planetGrid, rover);
            return rover.Backward(nextPoint);
        }

        private int GetNextPoint(Grid planetGrid, IRover rover)
        {
            var maxDistanceToMove = 1;
            var roverXPosition = rover.Position.XCoordinate;
            var roverYPosition = rover.Position.YCoordinate;

            var nextPoint = rover.Cardinal.Direction switch
            {
                CardinalDirection.North => roverYPosition - maxDistanceToMove,
                CardinalDirection.South => roverYPosition + maxDistanceToMove,
                CardinalDirection.East => roverXPosition - maxDistanceToMove,
                CardinalDirection.West => roverXPosition + maxDistanceToMove,
                _ => 0
            };

            return GetNextPointWrappedAroundGridEdge(nextPoint, planetGrid, rover);
        }

        private int GetNextPointWrappedAroundGridEdge(int nextPoint, Grid planetGrid, IRover rover)
        {
            if (RoverIsMovingHorizontally(rover))
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

        private bool WillRoverCollideWithObstacle(Grid planetGrid, int nextPoint, IRover rover)
        {
            foreach (var gridObstacle in planetGrid.Obstacles)
            {
                if (RoverIsMovingHorizontally(rover))
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

        private bool RoverIsMovingHorizontally(IRover rover) => rover.Cardinal.Direction == CardinalDirection.East || 
                                                                rover.Cardinal.Direction == CardinalDirection.West;
    }
}
