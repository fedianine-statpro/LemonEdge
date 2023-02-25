using Library.DataContract;
using Library.DataContract.Boards;
using Library.DataContract.ChessPieces;
using Xunit;

namespace Test
{
    public class ChessPieceTest
    {
        [Fact]
        public void Bishop_ValidMovesForEachLocation_ShouldReturnCorrectValues()
        {
            // Arrange
            Board board = new SquareBoard();
            Bishop bishop = new Bishop(board);

            // Act
            var validMoves = bishop.ValidMovesForEachLocation;

            // Assert
            Assert.Equal(new HashSet<Location> { new Location(1, 1) }, validMoves[new Location(0, 0)]);
            Assert.Equal(new HashSet<Location> { new Location(1, 0)}, validMoves[new Location(0, 1)]);
            Assert.Equal(new HashSet<Location> { new Location(0, 1)}, validMoves[new Location(1, 0)]);
            Assert.Equal(new HashSet<Location> { new Location(0, 0)}, validMoves[new Location(1, 1)]);
        }

        [Fact]
        public void ChessPiece_GetAllChessPieces_ShouldReturnAllChessPieces()
        {
            // Arrange
            Board board = new TelephoneKeyPad();

            // Act
            var chessPieces = ChessPiece.GetAllChessPieces(board);

            // Assert
            Assert.Equal(6, chessPieces.Length);
            Assert.Contains(chessPieces, p => p.GetType() == typeof(King));
            Assert.Contains(chessPieces, p => p.GetType() == typeof(Queen));
            Assert.Contains(chessPieces, p => p.GetType() == typeof(Knight));
            Assert.Contains(chessPieces, p => p.GetType() == typeof(Rook));
            Assert.Contains(chessPieces, p => p.GetType() == typeof(Bishop));
            Assert.Contains(chessPieces, p => p.GetType() == typeof(Pawn));
        }

        [Fact]
        public void ChessPiece_IsValidPosition_ShouldReturnTrueForValidPositions()
        {
            // Arrange
            Board board = new SquareBoard();
            ChessPiece chessPiece = new King(board);

            // Act & Assert
            Assert.True(chessPiece.IsValidPosition(0, 0));
            Assert.True(chessPiece.IsValidPosition(0, 1));
            Assert.True(chessPiece.IsValidPosition(1, 0));
            Assert.True(chessPiece.IsValidPosition(1, 1));
        }

        [Fact]
        public void ChessPiece_IsValidPosition_ShouldReturnFalseForInvalidPositions()
        {
            // Arrange
            Board board = new SquareBoard();
            ChessPiece chessPiece = new King(board);

            // Act & Assert
            Assert.False(chessPiece.IsValidPosition(-1, 0));
            Assert.False(chessPiece.IsValidPosition(0, -1));
            Assert.False(chessPiece.IsValidPosition(4, 0));
            Assert.False(chessPiece.IsValidPosition(0, 3));
        }
    }
}