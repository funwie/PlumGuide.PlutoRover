namespace PlumGuide.PlutoRover.API.Navigation
{
    public class CardinalEast : ICardinal
    {
        public ICardinal Left => new CardinalNorth();
        public ICardinal Right => new CardinalSouth();
        public CardinalDirection Direction => CardinalDirection.East;
    }
}
