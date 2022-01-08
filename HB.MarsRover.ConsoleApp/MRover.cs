using HB.MarsRover.ConsoleApp.Exceptions;
using System.Linq;

namespace HB.MarsRover.ConsoleApp
{
    public class MRover : BaseRover
    {
        private static readonly char[] directions = { 'N', 'E', 'S', 'W' };

        public override char Direction
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

        public MRover(IPlateau plateau, int x = 0, int y = 0, char direction = 'N')
            : base(x, y, direction)
        {
            LandedPlateau = plateau;

            if (x > LandedPlateau.X || y > LandedPlateau.Y)
                throw new InvalidPositionException();

            if (LandedPlateau.Rovers.Any(r => r.X == x && r.Y == y))
                throw new InvalidPositionException("Another rover is available at the same position!");

            X = x;
            Y = y;
            Direction = direction;
        }

        public override void Move(string command)
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
                        var nextX = X;
                        var nextY = Y;
                        switch (_direction)
                        {
                            case 0:
                                if (Y < LandedPlateau.Y)
                                    nextY++;
                                break;
                            case 1:
                                if (X < LandedPlateau.X)
                                    nextX++;
                                break;
                            case 2:
                                if (Y > 0)
                                    nextY--;
                                break;
                            case 3:
                                if (X > 0)
                                    nextX--;
                                break;
                            default:
                                throw new InvalidDirectionException();
                        }
                        if (LandedPlateau.Rovers.Any(r => r.X == nextX && r.Y == nextY))
                        {
                            //conflicts of rovers, do not move
                            break;
                        }
                        //move
                        X = nextX;
                        Y = nextY;
                        break;
                    default:
                        break;
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is IRover rover)
                return rover.X == X && rover.Y == Y;

            return false;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }
    }
}