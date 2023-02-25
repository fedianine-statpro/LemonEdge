using Library.DataContract.Boards;

namespace Library.DataContract.ChessPieces
{
    public record King : ChessPiece
    {
        public King(Board board) : base(board)
        {
            Name = "King";
            PossibleMoves = Enumerable.Range(-1, 3)
                .SelectMany(g => Enumerable.Range(-1, 3)
                    .Select(c => new Location(g,c))
                ).ToHashSet();
        }
    }
}
