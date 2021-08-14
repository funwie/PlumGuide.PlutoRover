namespace PlumGuide.PlutoRover.API.Navigation
{
    public class CardinalSouth : ICardinal
    {
        public ICardinal Left => new CardinalEast();
        public ICardinal Right => new CardinalWest();
        public CardinalDirection Direction => CardinalDirection.South;
    }
}
