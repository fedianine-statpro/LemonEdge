using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Test")]
namespace Library.DataContract.Boards
{
    // We support boards of all sizes and even non-rectangular or with empty spaces
    public record Board
    {
        public Board(string name, string[,] keypad)
        {
            Name = name;
            KeyPad = keypad;
        }
        internal int Columns => KeyPad.GetLength(1);
        internal int Rows => KeyPad.GetLength(0);
        internal string[,] KeyPad { get; init; }
        public string Name { get; init; }

        // Get string value located at specified location
        internal string GetKey(Location location)
        {
            return KeyPad[location.Row, location.Column];
        }
    }
}
