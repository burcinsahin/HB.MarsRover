using HB.MarsRover.ConsoleApp.Exceptions;

namespace HB.MarsRover.ConsoleApp
{
    public class Rover : IRover
    {
        private static readonly char[] directions = { 'N', 'E', 'S', 'W' };

        public IPlateau LandedPlateau { private get; set; }

        public int X { get; protected set; }
        public int Y { get; protected set; }
        public char Direction
        {
            get
            {
                return directions[_direction];
            }
            protected set
            {
                switch (value)
                {
                    case 'N':
                        _direction = 0;
                        break;
                    case 'E':
                        _direction = 1;
                        break;
                    case 'S':
                        _direction = 2;
                        break;
                    case 'W':
                        _direction = 3;
                        break;
                    default:
                        throw new InvalidDirectionException();
                }
            }
        }

        private sbyte _direction;

        public Rover(IPlateau plateau)
            : this(0, 0, 'N', plateau) { }

        public Rover(int x, int y, char direction, IPlateau plateau)
        {
            LandedPlateau = plateau;

            if (x > LandedPlateau.X || y > LandedPlateau.Y)
                throw new InvalidPositionException();

            X = x;
            Y = y;
            Direction = direction;
        }

        public void Move(string command)
        {
            foreach (var c in command)
            {
                switch (c)
                {
                    case 'L':
                        _direction--;
                        if (_direction < 0) _direction += 4;
                        break;
                    case 'R':
                        _direction++;
                        if (_direction > 3) _direction %= 4;
                        break;
                    case 'M':
                        switch (_direction)
                        {
                            case 0:
                                if (Y < LandedPlateau.Y)
                                    Y++;
                                break;
                            case 1:
                                if (X < LandedPlateau.X)
                                    X++;
                                break;
                            case 2:
                                if (Y > 0)
                                    Y--;
                                break;
                            case 3:
                                if (X > 0)
                                    X--;
                                break;
                            default:
                                throw new InvalidDirectionException();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public override string ToString()
        {
            return $"{X} {Y} {Direction}";
        }
    }
}
