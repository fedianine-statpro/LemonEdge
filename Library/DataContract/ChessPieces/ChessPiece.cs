using Library.DataContract.Boards;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Test")]
namespace Library.DataContract.ChessPieces
{
    public abstract record ChessPiece
    {
        internal ChessPiece(Board board)
        {
            Board = board;
        }

        public Board Board { get; init; }
        public string Name { get; init; }

        internal HashSet<Location> PossibleMoves { get; init; }

        public static ChessPiece[] GetAllChessPieces(Board board)
        {
            return new ChessPiece[]{
                new King(board),
                new Queen(board),
                new Knight(board),
                new Rook(board),
                new Bishop(board),
                new Pawn(board)
            };
        }

        /// <summary>
        /// Get all valid moves that can be made by specified chess piece
        /// </summary>
        /// <value>Returns dictionary of all valid moves from each individual starting location</value>
        internal Dictionary<Location, HashSet<Location>> ValidMovesForEachLocation
        {
            get
            {
                Dictionary<Location, HashSet<Location>> combinationsDictionary = new Dictionary<Location, HashSet<Location>>();
                for (int row = 0; row < Board.Rows; row++)
                {
                    for (int col = 0; col < Board.Columns; col++)
                    {
                        HashSet<Location> combinations = GetAvailableCombinations(row, col);
                        combinationsDictionary.Add(new Location(row, col), combinations);
                    }
                }

                return combinationsDictionary;
            }
        }

        /// <summary>
        /// Get all available valid moves from each individual location 
        /// </summary>
        /// <param name="row">Row on which chess piece is located</param>
        /// <param name="col">Column on which chess piece is located</param>
        /// <returns>Returns all valid moves that can be made from specified location on board</returns>
        private HashSet<Location> GetAvailableCombinations(int row, int col)
        {
            HashSet<Location> availableCombinations = new HashSet<Location>();
            foreach (Location move in PossibleMoves)
            {
                int newRow = row + move.Row;
                int newCol = col + move.Column;

                // Ensure we don't stay at the same place
                if (row == newRow && col == newCol)
                    continue;

                if (IsValidPosition(newRow, newCol))
                {
                    string key = Board.KeyPad[newRow, newCol];

                    // If keyboard has a null specified somewhere, we assume that that location is not available
                    // thus allowing us to handle boards that are not rectangular or contain empty field inside it
                    if (key != null)
                    {
                        availableCombinations.Add(new Location(newRow, newCol));
                    }
                }
            }

            return availableCombinations;
        }

        internal bool IsValidPosition(int row, int col)
        {
            return row >= 0 &&
                   col >= 0 &&
                   row < Board.Rows &&
                   col < Board.Columns &&
                   Board.KeyPad[row, col] != null;
        }
    }
}
