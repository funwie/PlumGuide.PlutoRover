namespace PlumGuide.PlutoRover.API.Commands
{
    public interface ICommand
    {
        bool CanExecute(Grid planetGrid, IRover rover);
        IRover Execute(Grid planetGrid, IRover rover);
    }
}
