using System;

namespace PlumGuide.PlutoRover.API.Commands
{
    public class TurnLeftCommand : ICommand
    {
        public bool CanExecute(Grid planetGrid, IRover rover)
        {
            return GridIsAvailable(planetGrid);
        }

        public IRover Execute(Grid planetGrid, IRover rover)
        {
            if (planetGrid is null) throw new ArgumentNullException(nameof(planetGrid));
            if (rover is null) throw new ArgumentNullException(nameof(rover));

            return rover.Turn(rover.Cardinal.Left);
        }

        private bool GridIsAvailable(Grid planetGrid)
        {
            return planetGrid != null && (planetGrid.Width > 0 || planetGrid.Height > 0);
        }
    }
}
