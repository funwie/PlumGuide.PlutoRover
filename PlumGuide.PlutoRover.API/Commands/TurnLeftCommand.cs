namespace PlumGuide.PlutoRover.API.Commands
{
    public class TurnLeftCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            rover.TurnLeft();
        }
    }
}
