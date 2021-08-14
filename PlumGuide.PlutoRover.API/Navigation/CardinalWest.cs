namespace PlumGuide.PlutoRover.API.Navigation
{
    public class CardinalWest : ICardinal
    {
        public ICardinal Left => new CardinalSouth();
        public ICardinal Right => new CardinalNorth();
        public CardinalDirection Direction => CardinalDirection.West;
    }
}
