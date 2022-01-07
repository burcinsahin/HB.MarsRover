namespace HB.MarsRover.ConsoleApp
{
    public interface IPlateau
    {
        /// <summary>
        /// X point of upper-right
        /// </summary>
        int X { get; }

        /// <summary>
        /// Y point of upper-right
        /// </summary>
        int Y { get; }

        /// <summary>
        /// Lands a new rover to plateau
        /// </summary>
        /// <param name="rover"></param>
        void Add(IRover rover);
    }
}