using System;

namespace HB.MarsRover.ConsoleApp.Exceptions
{
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException()
        {
        }

        public InvalidPositionException(string message) : base(message)
        {
        }
    }
}