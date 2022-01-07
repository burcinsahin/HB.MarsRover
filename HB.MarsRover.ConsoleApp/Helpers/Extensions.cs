namespace HB.MarsRover.ConsoleApp.Helpers
{
    public static class Extensions
    {
        public static bool IsOdd(this int number)
        {
            return number % 2 == 1;
        }

        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }
}
