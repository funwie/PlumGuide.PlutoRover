namespace PlumGuide.PlutoRover.API.Commands
{
    public class MoveBackwardCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            rover.Backward();
        }
    }
}
