using System.Collections.Generic;

namespace PlumGuide.PlutoRover.API.Commands
{
    public class RoverCommandFactory
    {
        private const char MoveForward = 'F';
        private const char MoveBackward = 'B';
        private const char TurnLeft = 'L';
        private const char TurnRight = 'R';

        private IReadOnlyDictionary<char, ICommand> _roverCommands;

        private readonly IRover _rover;

        public RoverCommandFactory(IRover rover)
        {
            _rover = rover;
            InitialiseRoverCommands();
        }

        public ICommand GetCommand(char commandLetter)
        {
            return _roverCommands[commandLetter];
        }

        private void InitialiseRoverCommands()
        {
            _roverCommands = new Dictionary<char, ICommand>
            {
                {MoveForward, new MoveForwardCommand()},
                {MoveBackward, new MoveBackwardCommand()},
                {TurnLeft, new TurnLeftCommand()},
                {TurnRight, new TurnRightCommand()}
            };
        }
    }
}