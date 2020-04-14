namespace TicTacToe.Contracts
{
    public class MovePosition
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public MovePosition(int x, int y) { X = x; Y = y; }
    }
}
