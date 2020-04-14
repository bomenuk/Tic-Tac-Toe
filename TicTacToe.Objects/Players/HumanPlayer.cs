using TicTacToe.Contracts;
using TicTacToe.Objects.Game;

namespace TicTacToe.Objects.Players
{
    public class HumanPlayer : basePlayer
    {
        private const int MOVE_NORMALIZATION_MODIFIER = 1;        
        
        public HumanPlayer(PlayerSymbol symbol) { Name = "Human"; Symbol = symbol; }

        public Move MakeAMove(int x, int y)
        {            
            var move = new Move(this, new MovePosition(x, y));
            return move;
        }
    }
}
