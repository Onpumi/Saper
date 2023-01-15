
public interface IGameField
{
    public GridCells  Grid { get;}
    void DisplayCells( ICell[,] cells, int countColumns, int countRows, float scale);
}