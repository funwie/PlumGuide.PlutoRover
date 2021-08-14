using PlumGuide.PlutoRover.API.Commands;

namespace PlumGuide.PlutoRover.API
{
    public class RoverController
    {
        public IRover Rover { get; private set; }
        private readonly RoverCommandFactory _commandFactory;

        public RoverController(IRover rover)
        {
            Rover = rover;
            _commandFactory = new RoverCommandFactory(Rover);
        }

        public void ExecuteCommand(string fullCommand)
        {
            foreach (var commandLetter in fullCommand)
            {
                var command = _commandFactory.GetCommand(commandLetter);
                command.Execute(Rover);
            }
        }
    }
}
