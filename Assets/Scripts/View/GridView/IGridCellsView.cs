
public interface IGridCellsView
{
    public GridCells  Grid { get;}
    void DisplayCells( Cell[,] cells, int countColumns, int countRows, float scale);
}
