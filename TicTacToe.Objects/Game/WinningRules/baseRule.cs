namespace TicTacToe.Objects.Game.WinningRules
{
    public abstract class baseRule
    {
        public const int Board_Size = 3;
        public const int Number_Of_Positions_To_Win = 3;
        public abstract bool IsWinning(int?[][] board);
    }
}
