
public interface IGridCellsView
{
    public GridCells<ViewCell>  Grid { get;}
    void DisplayCells( ICell[,] cells, int countColumns, int countRows, float scale);
}
