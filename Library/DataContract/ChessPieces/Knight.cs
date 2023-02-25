using Library.DataContract.Boards;

namespace Library.DataContract.ChessPieces
{
    public record Knight : ChessPiece
    {
        public Knight(Board board) : base(board)
        {
            Name = "Knight";
            PossibleMoves = new HashSet<Location>
            {
                new(2, 1), 
                new ( 2, -1 ), 
                new ( -2, 1 ), 
                new ( -2, -1 ), 
                new ( 1, 2 ), 
                new ( 1, -2 ), 
                new ( -1, 2 ), 
                new ( -1, -2 )
            };
        }
    }
}
