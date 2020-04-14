using System.Linq;
using TicTacToe.Contracts;

namespace TicTacToe.Objects.Game.WinningRules
{
    public class RowRule : baseRule
    {        
        public override bool IsWinning(int?[][] board)
        {
            bool winning = false;
            for (int i = 0; i < Board_Size; i++)
            {
                if (board[i].All(x => x == (int)PlayerSymbol.Circle) || board[i].All(x => x == (int)PlayerSymbol.Cross))
                {
                    winning = true;
                }
            }
            return winning;
        }
    }
}
