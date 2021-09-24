using System.Collections.Generic;

namespace ConnectionFour.Service.BusinessLogic
{
    public static class GameRules
    {
        public const char PlayerOnePosition = 'A';
        public const char PlayerTwoPosition = 'B';
        public const char EmptyPosition = 'X';
        public const int VectorLength = 42;
        public const int TotalPositionsPerColumn = 6;
        public const int TotalPositionsPerRow = 7;

        public static readonly List<char> Players = new() { PlayerOnePosition, PlayerTwoPosition };
        public static readonly List<char> ValidPositions = new(Players) { EmptyPosition };
    }
}
