using Library.DataContract.Boards;

namespace Library.DataContract.ChessPieces
{
    public record Queen : ChessPiece
    {
        public Queen(Board board) : base(board)
        {
            Name = "Queen";
            PossibleMoves = Enumerable.Range(-board.Rows + 1, board.Rows * 2 - 1)
                .SelectMany(g => Enumerable.Range(-board.Columns + 1, board.Columns * 2 - 1)
                    .Select(c => new Location(g,c))
                ).ToHashSet();
        }
    }
}
