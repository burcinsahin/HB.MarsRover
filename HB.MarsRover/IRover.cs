namespace HB.MarsRover
{
    internal interface IRover
    {
        int X { get; }
        int Y { get; }
        char Direction { get; }

        void Move(string command);
    }
}