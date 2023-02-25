using Library.DataContract.Boards;

namespace Library.DataContract.ChessPieces
{
    public record Rook : ChessPiece
    {
        public Rook(Board board) : base(board)
        {
            Name = "Rook";
            PossibleMoves = new HashSet<Location>();
            for (int row = -board.Rows + 1; row < board.Rows; row++)
            {
                PossibleMoves.Add(new Location(row, 0));
            }
            for (int column = -board.Columns + 1; column < board.Columns; column++)
            {
                PossibleMoves.Add(new Location(0, column));
            }
        }
    }
}
