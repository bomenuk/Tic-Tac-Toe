using TicTacToe.Contracts;

namespace TicTacToe.Objects.Players
{
    public abstract class basePlayer
    {
        public string Name { get; protected set; }
        public PlayerSymbol Symbol { get; protected set; }
    }
}
