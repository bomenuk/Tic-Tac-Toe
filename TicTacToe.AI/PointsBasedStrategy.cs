using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.AI;
using TicTacToe.Contracts;

namespace TicTacToe.Objects.Players.AIStrategies
{
    public class PointsBasedStrategy : baseStrategy, IStrategy
    {
        private const int WINNING_POINTS = 100;
        private const int STOPOPPONENTWINNING_POINTS = 50;
        private const int POSSIBLESTEP_POINTS = 5;
        private const int OPPONENTPOSSIBLESTEP_POINTS = 3;
        private const int INVALIDSTEP_POINTS = 0;

        private readonly int _strategySearchDepth = 3;
        private PlayerSymbol _mySymbol;
        private PlayerSymbol _opponentSymbol;

        public PointsBasedStrategy(PlayerSymbol mySymbol, PlayerSymbol opponentSymbol, int strategySearchDepth) 
        {
            _mySymbol = mySymbol;
            _opponentSymbol = opponentSymbol;
            _strategySearchDepth = strategySearchDepth;
        }
    
        public MovePosition CalculateNextMove(int?[][] board)
        {
            var selfPositions = GetPlayerMovePositions(board, _mySymbol);
            var opponentPositions = GetPlayerMovePositions(board, _mySymbol);
            var emptyPositions = GetEmptyMovePositions(board);

            var positionScoreList = GetPositionScoresForAllEmptyPositions(selfPositions, opponentPositions, emptyPositions);
            var position = positionScoreList.OrderByDescending(p => p.Score).FirstOrDefault();
            if(position != null)
            {
                return position.Position;
            }
            return null;
        }

        private List<PositionScore> GetPositionScoresForAllEmptyPositions(List<MovePosition> selfPositions, List<MovePosition> opponentPositions, List<MovePosition> emptyPositions)
        {
            var scoreList = new List<PositionScore>();

            return scoreList;
        }

        class PositionScore
        {
            public MovePosition Position { get; set; }
            public int Score { get; set; }
        }
    }
}
