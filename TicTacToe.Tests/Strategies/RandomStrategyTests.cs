using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TicTacToe.Objects.Players.AIStrategies;

namespace TicTacToe.Tests.Strategies
{
    [TestClass]
    public class RandomStrategyTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Throw_NULLReferenceException_When_GameBoard_Is_Null()
        {            
            var strategy = new RandomStrategy();
            strategy.CalculateNextMove(null);            
        }

        [TestMethod]        
        public void Return_Random_Position_Given_GameBoard()
        {
            var board = new int?[3][];
            board[0] = new int?[3] { 1, 2, 1 };
            board[1] = new int?[3] { 2, null, 1 };
            board[2] = new int?[3] { null, 1, 1 };
            var strategy = new RandomStrategy();
            var position = strategy.CalculateNextMove(board);

            Assert.IsTrue((position.X == 1 && position.Y == 1) || (position.X == 2 && position.Y == 0));
        }
    }
}
