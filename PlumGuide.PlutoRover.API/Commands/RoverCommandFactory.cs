using System.Collections.Generic;
using PlumGuide.PlutoRover.API.Exceptions;

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
            if (_roverCommands.TryGetValue(commandLetter, out var command))
            {
                return command;
            }

            throw new UnsupportedCommandException($"{commandLetter} is not supported by the rover");
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