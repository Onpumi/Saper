using System;
using UnityEngine;

public class DigDownAction : IDownAction
{
    private readonly IGridCellsView _gridCellsView;

    public DigDownAction( IGridCellsView gridCellsView )
    {
        _gridCellsView = gridCellsView ?? throw new ArgumentNullException("Grid Cells can't be null");
    }

    public void Select( ICell cell )
    {
        var grid = _gridCellsView.Grid;
        if (cell.TryOpen() == false)
        {
            foreach (var cellOther in grid.Cells)
            {
                cellOther.Open();       
            }
        }
        else if( cell is CellMine  )
        {
            //Debug.Log("Boom!");
           //_gridCellsView.DisplayCells();
        }

    }
}
