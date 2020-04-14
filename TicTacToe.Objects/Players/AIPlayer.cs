using TicTacToe.Objects.Game;
using TicTacToe.Objects.Players.AIStrategies;
using TicTacToe.Contracts;

namespace TicTacToe.Objects.Players
{
    public class AIPlayer : basePlayer
    {
        private readonly IStrategy _strategy;
        public AIPlayer(PlayerSymbol symbol, IStrategy strategy) { Name = "AI"; Symbol = symbol; _strategy = strategy; }
        public Move MakeAMove(int?[][] board)
        {
            return new Move(this, _strategy.CalculateNextMove(board));
        }
    }
}
