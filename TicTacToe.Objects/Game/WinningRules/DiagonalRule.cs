using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Objects.Game.WinningRules
{
    public class DiagonalRule : baseRule
    {
        public override bool IsWinning(int?[][] board)
        {
            bool winning = false;
            //Check diagonal towards bottom right
            var firstCellValue = board[0][0];            
            if (firstCellValue.HasValue)
            {
                var positionList = new List<int>();
                for (int i = 0; i < Board_Size; i++)
                {
                    if (board[i][i].HasValue)
                    {
                        positionList.Add(board[i][i].Value);
                    }
                }
                if (positionList.Count == Number_Of_Positions_To_Win && positionList.All(o => o == firstCellValue))
                {
                    winning = true;
                }
            }

            if (!winning)
            {
                //Check diagonal towards upper right
                firstCellValue = board[0][Board_Size - 1];
                if (firstCellValue.HasValue)
                {
                    var positionList = new List<int>();                    
                    for (int j = Board_Size - 1; j >= 0; j--)
                    {
                        if (board[Board_Size - 1 - j][j].HasValue)
                        {
                            positionList.Add(board[Board_Size - 1 - j][j].Value);
                        }
                    }
                    if (positionList.Count == Number_Of_Positions_To_Win && positionList.All(o => o == firstCellValue))
                    {
                        winning = true;
                    }
                }
            }
            return winning;
        }
    }
}
