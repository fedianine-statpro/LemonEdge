
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Test")]
namespace Library.DataContract
{
    internal record Location
    {
        internal Location(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public int Row { get; init; }
        public int Column { get; init; }
    }
}
