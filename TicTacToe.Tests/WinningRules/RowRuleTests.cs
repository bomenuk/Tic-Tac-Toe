using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Objects.Game.WinningRules;

namespace TicTacToe.Tests.WinningRules
{
    [TestClass]
    public class RowRuleTests
    {
        [TestMethod]
        public void Return_True_When_3_Positions_Have_Same_Symbol_In_A_Row()
        {
            var board = new int?[3][];
            board[0] = new int?[3] { 1, 1, 1 };
            board[1] = new int?[3] { 2, null, 1 };
            board[2] = new int?[3] { null, 1, 1 };

            var rule = new RowRule();
            Assert.IsTrue(rule.IsWinning(board));
        }

        [TestMethod]
        public void Return_False_When_3_Positions_Have_Same_Symbol_In_A_Row()
        {
            var board = new int?[3][];
            board[0] = new int?[3] { 1, null, 1 };
            board[1] = new int?[3] { 2, null, 1 };
            board[2] = new int?[3] { null, 1, 1 };

            var rule = new RowRule();
            Assert.IsFalse(rule.IsWinning(board));
        }
    }
}
