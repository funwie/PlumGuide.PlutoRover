namespace PlumGuide.PlutoRover.API.Commands
{
    public class TurnRightCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            rover.TurnRight();
        }
    }
}
