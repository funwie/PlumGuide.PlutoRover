using PlumGuide.PlutoRover.API.Navigation;

namespace PlumGuide.PlutoRover.API
{
    public interface IRover
    {
        Position Position { get; }
        ICardinal Cardinal { get; }
        void Forward();
        void Backward();
        void TurnLeft();
        void TurnRight();
    }
}
