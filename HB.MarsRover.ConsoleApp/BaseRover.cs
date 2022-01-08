namespace HB.MarsRover.ConsoleApp
{
    public abstract class BaseRover : IRover
    {
        public IPlateau LandedPlateau { protected get; set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public virtual char Direction { get; protected set; }

        public BaseRover(int x, int y, char direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public abstract void Move(string command);

        public override string ToString()
        {
            return $"{X} {Y} {Direction}";
        }
    }
}