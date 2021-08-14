namespace PlumGuide.PlutoRover.API.Commands
{
    public interface ICommand
    {
        void Execute(IRover rover);
    }
}
