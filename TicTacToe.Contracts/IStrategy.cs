using TicTacToe.Contracts;

namespace TicTacToe.Contracts
{
    public interface IStrategy
    {
        public MovePosition CalculateNextMove(int?[][] board);
    }
}
