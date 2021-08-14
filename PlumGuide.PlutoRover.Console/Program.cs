using PlumGuide.PlutoRover.API;
using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var coordinate = new Position(0, 0);
            var plutoRover = new API.PlutoRover(coordinate, new CardinalNorth());
            var controller = new RoverController(plutoRover);

            controller.ExecuteCommand("FFRFF");

            var roverState = controller.Rover;

            System.Console.WriteLine(roverState.Cardinal.ToString());
        }
    }
}
