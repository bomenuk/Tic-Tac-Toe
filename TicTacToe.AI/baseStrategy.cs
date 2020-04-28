using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Contracts;

namespace TicTacToe.AI
{
    public abstract class baseStrategy
    {
        protected List<MovePosition> GetPlayerMovePositions(int?[][] board, PlayerSymbol playerSymbol)
        {
            var playerPositionList = new List<MovePosition>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == (int)playerSymbol)
                    {
                        playerPositionList.Add(new MovePosition(i, j));
                    }
                }
            }
            return playerPositionList;
        }

        protected List<MovePosition> GetEmptyMovePositions(int?[][] board)
        {
            var emptyPositionList = new List<MovePosition>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (!board[i][j].HasValue)
                    {
                        emptyPositionList.Add(new MovePosition(i, j));
                    }
                }
            }

            return emptyPositionList;
        }
    }
}
