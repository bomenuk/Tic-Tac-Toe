using System.Linq;
using System.Collections.Generic;
using TicTacToe.Objects.Players;
using TicTacToe.Objects.Game.WinningRules;
using TicTacToe.Contracts;

namespace TicTacToe.Objects.Game
{
    public class GameBoard
    {
        private const int Board_SIZE = 3;
        private const int MAX_X_BOARDER = 2;
        private const int MAX_Y_BOARDER = 2;

        public int?[][] Board;
        public List<GameErrorTypes> CurrentErrors;
        public PlayerSymbol NextPlayerSymbol;
        public bool GameEnd;
        public basePlayer CurrentPlayer;
        public basePlayer Winner;
        private List<baseRule> _winningRules;

        public GameBoard(PlayerSymbol firstPlayerToStartGame, List<baseRule> rules)
        {
            InitializeGameBoard();
            CurrentErrors = new List<GameErrorTypes>();
            NextPlayerSymbol = firstPlayerToStartGame;
            GameEnd = false;
            CurrentPlayer = null;
            Winner = null;
            _winningRules = rules;
        }

        private void InitializeGameBoard()
        {
            Board = new int?[Board_SIZE][];
            for (int i = 0; i < Board_SIZE; i++)
            {
                Board[i] = new int?[Board_SIZE];
            }
        }

        public bool ValidateMove(Move move)
        {
            bool success = true;
            CurrentErrors.Clear();
            if (move.Player.Symbol != NextPlayerSymbol)
            {
                CurrentErrors.Add(GameErrorTypes.WrongTurnForPlayer);
                success = false;
            }

            if (move.Position.X < 0 || move.Position.X > MAX_X_BOARDER || move.Position.Y < 0 || move.Position.Y > MAX_Y_BOARDER)
            {
                CurrentErrors.Add(GameErrorTypes.MoveOfOutBoard);
                return false;
            }

            if (Board[move.Position.X][move.Position.Y] != null)
            {
                CurrentErrors.Add(GameErrorTypes.PositionAlreadyTaken);
                return false;
            }
            return success;
        }

        public int?[][] TakeAMove(Move move)
        {
            Board[move.Position.X][move.Position.Y] = (int)move.Player.Symbol;
            NextPlayerSymbol = (PlayerSymbol)((int)PlayerSymbol.Circle + (int)PlayerSymbol.Cross - (int)move.Player.Symbol);
            CurrentPlayer = move.Player;
            return Board;
        }

        public bool IsGameEnd()
        {
            if (Board.All(p => p.All(x => x.HasValue)))
            {
                GameEnd = true;
            }
            return GameEnd;
        }

        public bool IsWinning()
        {
            var winning = _winningRules.Any(r => r.IsWinning(Board));
            if (winning)
            {
                Winner = CurrentPlayer;
            }
            return winning;
        }
    }
}
