using System;
using System.Collections.Generic;

namespace HB.MarsRover
{
    public class Rover : IRover
    {
        private static readonly char[] directions = { 'N', 'E', 'S', 'W' };

        public int X { get; protected set; }
        public int Y { get; protected set; }
        public char Direction { get { return directions[_direction]; } }

        private byte _direction;

        public Rover(int x, int y, char direction)
        {
            X = x;
            Y = y;
            SetDirection(direction);
        }

        private void SetDirection(char direction)
        {
            switch (direction)
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
                    throw new Exception("Invalid Direction!");
            }
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
                        if (_direction > 4) _direction %= 4;
                        break;
                    case 'M':
                        switch (_direction)
                        {
                            case 0:
                                Y++;
                                break;
                            case 1:
                                X++;
                                break;
                            case 2:
                                Y--;
                                break;
                            case 3:
                                X--;
                                break;
                            default:
                                throw new NotSupportedException("Invalid Direction!");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
