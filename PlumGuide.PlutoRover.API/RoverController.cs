using System;
using PlumGuide.PlutoRover.API.Commands;

namespace PlumGuide.PlutoRover.API
{
    public class RoverController
    {
        public IRover Rover { get; private set; }
        public Grid PlanetGrid { get; }

        private readonly RoverCommandFactory _commandFactory;

        public RoverController(IRover rover, Grid planetGrid)
        {
            Rover = rover;
            PlanetGrid = planetGrid;
            _commandFactory = new RoverCommandFactory(Rover);
        }

        public void ExecuteCommand(string fullCommand)
        {
            foreach (var commandLetter in fullCommand)
            {
                var command = _commandFactory.GetCommand(commandLetter);
                if (command.CanExecute(PlanetGrid) is false)
                {
                    throw new InvalidOperationException($"Unable to execute command {command.GetType().Name} with letter {commandLetter}");
                }

                Rover = command.Execute(PlanetGrid);
            }
        }
    }
}
