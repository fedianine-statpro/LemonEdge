using Library.DataContract.Boards;
using Library.DataContract.ChessPieces;
using Library.DataContract;
using Library;
using System.Text.RegularExpressions;
using Xunit;

namespace Test
{
    public class PhoneNumberTests
    {
        private readonly ChessPiece _chessPiece;

        public PhoneNumberTests()
        {
            // Initialize test data
            Board board = new SquareBoard();
            _chessPiece = new Pawn(board);
        }

        [Fact]
        public void CountPhoneNumbers_ReturnsCorrectCount_WhenValidMovesExist()
        {
            // Act
            var rules = new Rules(2, new Regex("[1-3]{2}"));
            int result = PhoneNumber.CountPhoneNumbers(_chessPiece, rules);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void CountPhoneNumbers_ReturnsZero_WhenTargetLengthIsZero()
        {
            // Act
            Action act = () => new Rules(0, new Regex("[1-3]{2}"));

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void CountPhoneNumbers_ReturnsZero_WhenRegexInvalid()
        {
            // Arrange
            var rules = new Rules(2, new Regex("^\\d{0}$"));

            // Act
            int result = PhoneNumber.CountPhoneNumbers(_chessPiece, rules);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountPhoneNumbers_ReturnsZero_WhenRegexInvalid_2()
        {
            // Arrange
            var rules = new Rules(2, new Regex("\\d{10}"));

            // Act
            int result = PhoneNumber.CountPhoneNumbers(_chessPiece, rules);

            // Assert
            Assert.Equal(0, result);
        }
    }
}
