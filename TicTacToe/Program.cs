using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Contracts;
using TicTacToe.Objects.Game;
using TicTacToe.Objects.Game.WinningRules;
using TicTacToe.Objects.Players;
using TicTacToe.Objects.Players.AIStrategies;

namespace TicTacToe
{
    class Program
    {
        private const string WELCOME_MESSAGE = @"Welcome to Tic-Tac-Toe game.";
        private const string INITIALIZE_MESSAGE = "Initializing empty game board to start....";
        private const string DISPLAY_CURRENT_BOARD = "Current board shown below:";
        private const string ASK_FOR_MOVE = "Please make a move in format: X Y";
        private const string MOVE_EXAMPLE = @"e.g. 1 3 will make place a move at position 1,3";
        private const string NEW_LINE = "\r\n";
        private const string INVALID_MOVE = @"Invalid move, please retry.";
        private const char ERROR = 'E';
        private const string AI_MOVE_MESSAGE = "AI move as:";
        private const string WINNER_MESSAGE = "Winner:";
        private const string DRAW_MESSAGE = "Game draw, no winner.";

        private const int MOVE_INPUT_STRING_LENGTH = 3;
        private const int MOVE_NORMALIZATION_MODIFIER = 1;

        static void Main(string[] args)
        {
            var rules = new List<baseRule>();
            rules.Add(new RowRule());
            rules.Add(new ColumnRule());
            rules.Add(new DiagonalRule());
            var gameBoard = new GameBoard(PlayerSymbol.Circle, rules);

            Console.WriteLine(WELCOME_MESSAGE);
            Console.WriteLine(INITIALIZE_MESSAGE);
            Console.WriteLine(DISPLAY_CURRENT_BOARD);
            DisplayCurrentBoard(gameBoard.Board);
            Console.WriteLine(ASK_FOR_MOVE);
            Console.WriteLine(MOVE_EXAMPLE);

            var humanPlayer = new HumanPlayer(PlayerSymbol.Circle);
            var aiPlayer = new AIPlayer(PlayerSymbol.Cross, new RandomStrategy());

            while (!(gameBoard.IsWinning() || gameBoard.IsGameEnd()))
            {
                Move humanMove = null;
                var userInput = Console.ReadLine().Trim();
                while (humanMove == null || !ValidateInput(userInput) || !gameBoard.ValidateMove(humanMove))
                {
                    if (!ValidateInput(userInput) || (humanMove != null && !gameBoard.ValidateMove(humanMove)))
                    {
                        Console.WriteLine(INVALID_MOVE);
                        DisplayCurrentBoard(gameBoard.Board);
                        Console.WriteLine(ASK_FOR_MOVE);
                        userInput = Console.ReadLine().Trim();
                    }
                    
                    humanMove = humanPlayer.MakeAMove(Int32.Parse(userInput[0].ToString()) - MOVE_NORMALIZATION_MODIFIER, Int32.Parse(userInput[2].ToString()) - MOVE_NORMALIZATION_MODIFIER);
                }
                gameBoard.TakeAMove(humanMove);
                DisplayCurrentBoard(gameBoard.Board);

                if (gameBoard.IsWinning() || gameBoard.IsGameEnd())
                {
                    break;
                }

                var aiMove = aiPlayer.MakeAMove(gameBoard.Board);
                while (!gameBoard.ValidateMove(aiMove))
                {
                    aiMove = aiPlayer.MakeAMove(gameBoard.Board);
                }
                Console.WriteLine($"{AI_MOVE_MESSAGE} X: {aiMove.Position.X + MOVE_NORMALIZATION_MODIFIER}, Y: {aiMove.Position.Y + MOVE_NORMALIZATION_MODIFIER}");
                gameBoard.TakeAMove(aiMove);
                DisplayCurrentBoard(gameBoard.Board);
            }

            if (gameBoard.Winner != null)
            {
                Console.WriteLine($"{WINNER_MESSAGE} {gameBoard.Winner.Name}");
            }
            else if (gameBoard.GameEnd)
            {
                Console.WriteLine(DRAW_MESSAGE);
            }
            Console.ReadKey();
        }

        private static void DisplayCurrentBoard(int?[][] board)
        {
            var boardToDisplay = new StringBuilder();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    boardToDisplay.Append($"{GetCellDisplaySymbol(board[i][j])} ");
                }
                boardToDisplay.Append(NEW_LINE);
            }
            Console.Write(boardToDisplay);
        }

        private static char GetCellDisplaySymbol(int? cellValue)
        {
            switch (cellValue)
            {
                case null:
                    return '-';
                case (int)PlayerSymbol.Circle:
                    return 'O';
                case (int)PlayerSymbol.Cross:
                    return 'X';
            }
            return ERROR;
        }

        private static bool ValidateInput(string input)
        {
            if (input.Length != MOVE_INPUT_STRING_LENGTH)
            {
                Console.WriteLine(INVALID_MOVE);
                return false;
            }

            if (!Int32.TryParse(input[0].ToString(), out var tempX))
            {
                return false;
            }

            if (!Int32.TryParse(input[2].ToString(), out var tempY))
            {
                return false;
            }
            return true;
        }
    }
}
