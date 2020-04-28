using System;
using TicTacToe.AI;
using TicTacToe.Contracts;

namespace TicTacToe.Objects.Players.AIStrategies
{
    public class RandomStrategy : baseStrategy, IStrategy
    {
        public MovePosition CalculateNextMove(int?[][] board)
        {
            var emptyPositionList = GetEmptyMovePositions(board);
            var rand = new Random();
            var position = rand.Next(emptyPositionList.Count);
            return emptyPositionList[position];
        }
    }
}
