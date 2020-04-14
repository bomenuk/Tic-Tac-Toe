using System;
using System.Collections.Generic;
using TicTacToe.Contracts;

namespace TicTacToe.Objects.Players.AIStrategies
{
    public class RandomStrategy : IStrategy
    {
        public MovePosition CalculateNextMove(int?[][] board)
        {
            var emptyCellList = new List<MovePosition>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (!board[i][j].HasValue)
                    {
                        emptyCellList.Add(new MovePosition(i, j));
                    }
                }
            }
            var rand = new Random();
            var position = rand.Next(emptyCellList.Count);
            return emptyCellList[position];
        }
    }
}
