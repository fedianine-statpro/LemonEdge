using Library.DataContract.Boards;

namespace Library.DataContract.ChessPieces
{
    public record Bishop : ChessPiece
    {
        public Bishop(Board board) : base(board)
        {
            Name = "Bishop";
            PossibleMoves = new HashSet<Location>();
            for (int row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Columns; col++)
                {
                    GenerateMovesInDirection(row, col, -1, -1); // upper left
                    GenerateMovesInDirection(row, col, -1, 1); // upper right
                    GenerateMovesInDirection(row, col, 1, -1); // lower left
                    GenerateMovesInDirection(row, col, 1, 1); // lower right
                }
            }
        }

        private void GenerateMovesInDirection(int row, int col, int deltaRow, int deltaCol)
        {
            for (int r = row + deltaRow, c = col + deltaCol; r >= 0 && r < Board.Rows && c >= 0 && c < Board.Columns; r += deltaRow, c += deltaCol)
            {
                PossibleMoves.Add(new Location(r - row, c - col));
            }
        }
    }
}
