using System;

namespace TicTacToe.Objects.Game.WinningRules
{
    public class ColumnRule : baseRule
    {
        public override bool IsWinning(int?[][] board)
        {
            bool winning = false;
            for (int i = 0; i < Board_Size; i++)
            {
                bool all3ColumnSameSymbol = true;
                var symbol = board[0][i];
                for (int j = 0; j < Board_Size; j++)
                {
                    if (!symbol.HasValue || board[j][i] != symbol)
                    {
                        all3ColumnSameSymbol = false;
                    }
                }
                if(all3ColumnSameSymbol)
                {
                    winning = true;
                    break;
                }
            }
            return winning;
        }
    }
}
