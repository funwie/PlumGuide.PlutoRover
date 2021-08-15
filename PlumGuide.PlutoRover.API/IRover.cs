using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API
{
    public interface IRover
    {
        Position Position { get; }
        ICardinal Cardinal { get; }
        IRover Forward(int toPoint);
        IRover Backward(int toPoint);
        IRover Turn(ICardinal cardinal);
    }
}
