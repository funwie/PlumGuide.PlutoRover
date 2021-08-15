using System.Collections.Generic;
using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API
{
    public class Grid
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public IReadOnlyList<Obstacle> Obstacles => _obstacles;

        private readonly List<Obstacle> _obstacles;

        public Grid()
        {
            _obstacles = new List<Obstacle>();
        }

        public void AddObstacle(Position placedAt, string name)
        {
            _obstacles.Add(new Obstacle(placedAt, name));
        }
    }
}
