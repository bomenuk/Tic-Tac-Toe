using TicTacToe.Contracts;

namespace TicTacToe.Objects.Players.AIStrategies
{
    public interface IStrategy
    {
        public MovePosition CalculateNextMove(int?[][] board);
    }
}
