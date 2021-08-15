namespace PlumGuide.PlutoRover.API.Commands
{
    public interface ICommand
    {
        bool CanExecute(Grid planetGrid);
        IRover Execute(Grid planetGrid);
    }
}
