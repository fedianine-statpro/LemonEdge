using Library.DataContract;
using Library.DataContract.Boards;
using Library.DataContract.ChessPieces;

namespace Library
{
    public static class PhoneNumber
    {
        /// <summary>
        /// Get number of phone numbers that comply to our rules can be generated with specified chess piece
        /// </summary>
        /// <param name="chessPiece">Chess piece</param>
        /// <param name="rules">Rules</param>
        /// <returns>Returns number phone numbers that can be generated using our rules</returns>
        public static int CountPhoneNumbers(ChessPiece chessPiece, Rules rules)
        {
            int totalPhoneNumbers = 0;

            // Get all valid combinations for the chess piece each location on the board
            var combinationsDictionary = chessPiece.ValidMovesForEachLocation;

            // Start generating phone number starting at each location on the board
            foreach (KeyValuePair<Location, HashSet<Location>> location in combinationsDictionary)
            {
                // Get first number of the phone number
                string partialPhoneNumber = chessPiece.Board.GetKey(location.Key);
                
                // Null means that there is empty square on the board that should not be used,
                // allowing support for non-rectangular boards or board that have empty spaces in the middle
                if (partialPhoneNumber != null)
                {
                    // Get all phone numbers that start with specified location
                    totalPhoneNumbers += GetNextNumber(combinationsDictionary, rules, chessPiece.Board, location.Value, partialPhoneNumber);
                }
            }

            return totalPhoneNumbers;
        }

        /// <summary>
        /// Get next number of the phone number (until we reach the length of phone number specified in the rules)
        /// </summary>
        /// <remarks>
        /// This method is intended to be called recursively
        /// </remarks>
        /// <returns>Returns number of phone numbers that match our rules.</returns>
        private static int GetNextNumber(Dictionary<Location, HashSet<Location>> combinationsDictionary, Rules rules, Board board, HashSet<Location> locations, string partialPhoneNumber)
        {
            int validPhoneNumbers = 0;
            string originalPartialPhoneNumber = partialPhoneNumber;
            foreach (Location location in locations)
            {
                partialPhoneNumber += board.GetKey(location);
                if (partialPhoneNumber.Length == rules.TargetLength)
                {
                    if (rules.IsValidString(partialPhoneNumber))
                    {
                        validPhoneNumbers++;
                    }

                    partialPhoneNumber = originalPartialPhoneNumber;
                }
                else
                {
                    validPhoneNumbers += GetNextNumber(combinationsDictionary, rules, board, combinationsDictionary[location], partialPhoneNumber);
                }
            }

            return validPhoneNumbers;
        }
    }
}
