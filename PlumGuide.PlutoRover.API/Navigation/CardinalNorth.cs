namespace PlumGuide.PlutoRover.API.Navigation
{
    public class CardinalNorth : ICardinal
    {
        public ICardinal Left => new CardinalWest();
        public ICardinal Right => new CardinalEast();
        public CardinalDirection Direction => CardinalDirection.North;
    }
}
