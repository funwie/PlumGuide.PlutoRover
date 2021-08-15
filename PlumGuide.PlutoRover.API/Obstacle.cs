using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API
{
    public class Obstacle
    {
        public Position Position { get; set; }
        public string Name { get; set; }

        public Obstacle(Position position, string name)
        {
            Position = position;
            Name = name;
        }
    }
}