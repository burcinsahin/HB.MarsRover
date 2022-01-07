namespace HB.MarsRover.ConsoleApp
{
    public interface IRover
    {
        /// <summary>
        /// X position
        /// </summary>
        int X { get; }
        /// <summary>
        /// Y position
        /// </summary>
        int Y { get; }
        /// <summary>
        /// Direction as N, E, S, W
        /// </summary>
        char Direction { get; }
        /// <summary>
        /// Landed Plateau
        /// </summary>
        IPlateau LandedPlateau { set; }

        /// <summary>
        /// Moves or rotates rover
        /// </summary>
        /// <param name="command">command such as RRRLLMMM</param>
        void Move(string command);
    }
}