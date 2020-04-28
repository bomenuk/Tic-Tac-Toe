using System;
using TicTacToe.AI;
using TicTacToe.Contracts;

namespace TicTacToe.Objects.Players.AIStrategies
{
    public class PointsBasedStrategy : baseStrategy, IStrategy
    {
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
            throw new NotImplementedException();
        }
    }
}
