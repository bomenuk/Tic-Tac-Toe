using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Contracts;
using TicTacToe.Objects.Game;
using TicTacToe.Objects.Game.WinningRules;
using TicTacToe.Objects.Players;

namespace TicTacToe.Tests
{
    [TestClass]
    public class GameBoardTests
    {
        List<baseRule> rules = new List<baseRule>();
        GameBoard gameBoard;

        [TestInitialize]
        public void TestInitialize()
        {
            rules = new List<baseRule>();
            rules.Add(new RowRule());
            rules.Add(new ColumnRule());
            rules.Add(new DiagonalRule());
            gameBoard = new GameBoard(PlayerSymbol.Circle, rules);
        }

        [TestMethod]
        public void Check_If_Initailize_Properties_Correctly_In_GameBoard_Constructor()
        {
            Assert.IsNotNull(gameBoard.Board);
            Assert.IsTrue(gameBoard.Board.All(p => p.All(x => !x.HasValue)));
            Assert.IsNotNull(gameBoard.CurrentErrors);
            Assert.AreEqual(PlayerSymbol.Circle, gameBoard.NextPlayerSymbol);
            Assert.IsFalse(gameBoard.GameEnd);
            Assert.IsNull(gameBoard.CurrentPlayer);
            Assert.IsNull(gameBoard.Winner);
        }

        [TestMethod]
        public void Check_If_ValidateMove_Return_WrongTurnForPlayer_Error()
        {
            var player = new HumanPlayer(PlayerSymbol.Cross);
            var move = new Move(player, new MovePosition(0, 0));
            var result = gameBoard.ValidateMove(move);

            Assert.IsFalse(result);
            Assert.AreEqual(1, gameBoard.CurrentErrors.Count);
            Assert.AreEqual(GameErrorTypes.WrongTurnForPlayer, gameBoard.CurrentErrors[0]);
        }

        [TestMethod]
        [DataRow(-1, 0)]
        [DataRow(3, 0)]
        [DataRow(-1, 5)]
        public void Check_If_ValidateMove_Return_MoveOfOutBoard_Error(int x, int y)
        {
            var player = new HumanPlayer(PlayerSymbol.Circle);
            var move = new Move(player, new MovePosition(x, y));
            var result = gameBoard.ValidateMove(move);

            Assert.IsFalse(result);
            Assert.AreEqual(1, gameBoard.CurrentErrors.Count);
            Assert.AreEqual(GameErrorTypes.MoveOfOutBoard, gameBoard.CurrentErrors[0]);
        }

        [TestMethod]
        public void Check_If_ValidateMove_Return_PositionAlreadyTaken_Error()
        {
            var player = new HumanPlayer(PlayerSymbol.Circle);
            var move = new Move(player, new MovePosition(0, 0));
            gameBoard.TakeAMove(move);
            var player2 = new HumanPlayer(PlayerSymbol.Cross);
            var move2 = new Move(player2, new MovePosition(0, 0));
            var result = gameBoard.ValidateMove(move2);

            Assert.IsFalse(result);
            Assert.AreEqual(1, gameBoard.CurrentErrors.Count);
            Assert.AreEqual(GameErrorTypes.PositionAlreadyTaken, gameBoard.CurrentErrors[0]);
        }

        [TestMethod]
        public void Check_If_TakeAMove_Can_Set_Correct_Properties()
        {
            var player = new HumanPlayer(PlayerSymbol.Circle);
            var move = new Move(player, new MovePosition(1, 2));
            gameBoard.TakeAMove(move);

            Assert.AreEqual((int)PlayerSymbol.Circle, gameBoard.Board[move.Position.X][move.Position.Y]);
            Assert.AreEqual(PlayerSymbol.Cross, gameBoard.NextPlayerSymbol);
            Assert.AreEqual(player, gameBoard.CurrentPlayer);
        }

        [TestMethod]
        public void Return_False_If_There_Are_Empty_Positions_And_No_Player_Is_Winning()
        {
            var player1 = new HumanPlayer(PlayerSymbol.Circle);
            var move = new Move(player1, new MovePosition(0, 0));
            gameBoard.TakeAMove(move);
            var player2 = new HumanPlayer(PlayerSymbol.Cross);
            var move2 = new Move(player2, new MovePosition(1, 1));
            gameBoard.TakeAMove(move2);

            Assert.IsFalse(gameBoard.IsGameEnd());
        }

        [TestMethod]
        public void Return_True_If_There_Are_No_Empty_Positions_And_No_Player_Is_Winning()
        {
            var player1 = new HumanPlayer(PlayerSymbol.Circle);
            var player2 = new HumanPlayer(PlayerSymbol.Cross);
            var move1 = new Move(player1, new MovePosition(0, 0));
            var move2 = new Move(player2, new MovePosition(1, 1));
            gameBoard.TakeAMove(move1);
            gameBoard.TakeAMove(move2); 
            var move3 = new Move(player1, new MovePosition(0, 1));
            var move4 = new Move(player2, new MovePosition(0, 2));
            gameBoard.TakeAMove(move3);
            gameBoard.TakeAMove(move4);
            var move5 = new Move(player1, new MovePosition(2, 1));
            var move6 = new Move(player2, new MovePosition(1, 0));
            gameBoard.TakeAMove(move5);
            gameBoard.TakeAMove(move6);
            var move7 = new Move(player1, new MovePosition(1, 2));
            var move8 = new Move(player2, new MovePosition(2, 2));
            gameBoard.TakeAMove(move7);
            gameBoard.TakeAMove(move8);
            var move9 = new Move(player1, new MovePosition(2, 0));
            gameBoard.TakeAMove(move9);

            Assert.IsTrue(gameBoard.IsGameEnd());
        }

        [TestMethod]
        public void Return_False_If_No_Player_Is_Winning()
        {
            var player1 = new HumanPlayer(PlayerSymbol.Circle);
            var player2 = new HumanPlayer(PlayerSymbol.Cross);
            var move1 = new Move(player1, new MovePosition(0, 0));
            var move2 = new Move(player2, new MovePosition(1, 1));
            gameBoard.TakeAMove(move1);
            gameBoard.TakeAMove(move2);
            var move3 = new Move(player1, new MovePosition(0, 1));
            var move4 = new Move(player2, new MovePosition(0, 2));
            gameBoard.TakeAMove(move3);
            gameBoard.TakeAMove(move4);
            var move5 = new Move(player1, new MovePosition(2, 1));
            var move6 = new Move(player2, new MovePosition(1, 0));
            gameBoard.TakeAMove(move5);
            gameBoard.TakeAMove(move6);
            var move7 = new Move(player1, new MovePosition(1, 2));
            var move8 = new Move(player2, new MovePosition(2, 2));
            gameBoard.TakeAMove(move7);
            gameBoard.TakeAMove(move8);
            var move9 = new Move(player1, new MovePosition(2, 0));
            gameBoard.TakeAMove(move9);

            Assert.IsFalse(gameBoard.IsWinning());
        }

        [TestMethod]
        public void Return_False_If_1_Player_Is_Winning()
        {
            var player1 = new HumanPlayer(PlayerSymbol.Circle);
            var player2 = new HumanPlayer(PlayerSymbol.Cross);
            var move1 = new Move(player1, new MovePosition(0, 0));
            var move2 = new Move(player2, new MovePosition(1, 1));
            gameBoard.TakeAMove(move1);
            gameBoard.TakeAMove(move2);
            var move3 = new Move(player1, new MovePosition(0, 1));
            var move4 = new Move(player2, new MovePosition(1, 0));
            gameBoard.TakeAMove(move3);
            gameBoard.TakeAMove(move4);
            var move5 = new Move(player1, new MovePosition(0, 2));
            gameBoard.TakeAMove(move5);

            Assert.IsTrue(gameBoard.IsWinning());
        }
    }
}
