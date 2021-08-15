using System;

namespace PlumGuide.PlutoRover.API.Commands
{
    public class TurnLeftCommand : ICommand
    {
        private readonly IRover _rover;

        public TurnLeftCommand(IRover rover)
        {
            _rover = rover ?? throw new ArgumentNullException(nameof(rover));
        }

        public bool CanExecute(Grid planetGrid)
        {
            return GridIsAvailable(planetGrid);
        }

        public IRover Execute(Grid planetGrid)
        {
           return _rover.Turn(_rover.Cardinal.Left);
        }

        private bool GridIsAvailable(Grid planetGrid)
        {
            return planetGrid != null && (planetGrid.Width > 0 || planetGrid.Height > 0);
        }
    }
}
