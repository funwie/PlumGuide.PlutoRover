namespace PlumGuide.PlutoRover.API.Navigation
{
    public class Position
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }

        public Position(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}
