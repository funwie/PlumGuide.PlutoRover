namespace PlumGuide.PlutoRover.API.Navigation
{
    public interface ICardinal
    {
        ICardinal Left { get; }
        ICardinal Right { get; }
        CardinalDirection Direction { get; }
    }
}
