using System.Text.RegularExpressions;
using Library;
using Library.DataContract;
using Library.DataContract.Boards;
using Library.DataContract.ChessPieces;

namespace LemonEdge
{
    // This solution was written in 3.5 hours by Victor Fedianine
    internal class Program
    {
        static void Main(string[] args)
        {
            // Phone number must be
            // - Seven digits in length 
            // - Cannot start with a 0 or 1 
            // - Cannot contain a * or #
            Rules rules = new Rules(7, new Regex("^[2-9]\\d{6}$"));

            TelephoneKeyPad telephoneKeyPad = new TelephoneKeyPad();
            ChessPiece[] chessPiecesOnTelephoneKeyPad = ChessPiece.GetAllChessPieces(telephoneKeyPad);
            PrintNumberOfPhoneNumbersPerChessPiece(chessPiecesOnTelephoneKeyPad, rules);

            SquareBoard squareBoard = new SquareBoard();
            ChessPiece[] chessPiecesOnSquareBoard = ChessPiece.GetAllChessPieces(squareBoard);
            PrintNumberOfPhoneNumbersPerChessPiece(chessPiecesOnSquareBoard, rules);

            DoughnutBoard doughnutBoard = new DoughnutBoard();
            ChessPiece[] chessPiecesOnDoughnutBoard = ChessPiece.GetAllChessPieces(doughnutBoard);
            PrintNumberOfPhoneNumbersPerChessPiece(chessPiecesOnDoughnutBoard, rules);

            Console.ReadLine();
        }
        
        /// <summary>
        /// Print number of phone numbers that can be created using the rules provided
        /// </summary>
        /// <param name="chessPieces">An array of various chess pieces</param>
        /// <param name="rules">Rules for generation of phone numbers</param>
        private static void PrintNumberOfPhoneNumbersPerChessPiece(ChessPiece[] chessPieces, Rules rules)
        {
            foreach (var chessPiece in chessPieces)
            {
                var totalPhoneNumbers = PhoneNumber.CountPhoneNumbers(chessPiece, rules);
                Console.WriteLine($"For {chessPiece.Name} on a {chessPiece.Board.Name} we were able to generate {totalPhoneNumbers} valid phone numbers.");
            }
        }
    }
}