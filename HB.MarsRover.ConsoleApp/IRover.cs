namespace HB.MarsRover.ConsoleApp
{
    public interface IRover
    {
        int X { get; }
        int Y { get; }
        char Direction { get; }
        IPlateau LandedPlateau { set; }

        void Move(string command);
    }
}