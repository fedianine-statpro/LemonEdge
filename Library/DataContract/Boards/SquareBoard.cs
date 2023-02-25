namespace Library.DataContract.Boards
{
    public record SquareBoard() : Board("Two by Two board", new[,] { { "1", "2" }, { "3", "4" } });
}
