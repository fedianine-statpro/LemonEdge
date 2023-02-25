using Library.DataContract.Boards;

namespace Library.DataContract.ChessPieces
{
    public record Pawn : ChessPiece
    {
        public Pawn(Board board) : base(board)
        {
            Name = "Pawn";
            
            // We make assumptions that pawn can only move 1 move up or one move down
            PossibleMoves = new HashSet<Location>
            {
                new(-1, 0),
                new ( 1, 0 )
            };
        }
    }
}
