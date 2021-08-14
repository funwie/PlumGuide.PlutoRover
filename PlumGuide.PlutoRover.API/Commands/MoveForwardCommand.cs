namespace PlumGuide.PlutoRover.API.Commands
{
    public class MoveForwardCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            rover.Forward();
        }
    }
}
