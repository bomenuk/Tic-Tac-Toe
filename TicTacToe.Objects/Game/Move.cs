using TicTacToe.Contracts;
using TicTacToe.Objects.Players;

namespace TicTacToe.Objects.Game
{
    public class Move
    {
        public basePlayer Player {get; private set;}
        public MovePosition Position { get; private set; }

        public Move(basePlayer player, MovePosition position)
        {
            Player = player;
            Position = position;
        }
    }
}
