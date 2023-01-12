using System;
using UnityEngine;

public class FirstDigDownAction : IDownAction
{
    private readonly IGridCellsView _gridCellsView;

    public FirstDigDownAction( IGridCellsView gridCellsView )
    {
        _gridCellsView = gridCellsView ?? throw new ArgumentNullException("Grid Cells can't be null");
    }

    public void Select( ICell cell )
    {
        _gridCellsView.Grid.FindFirstIndexesOnClick( cell );
        _gridCellsView.Grid.ConfirmFirstClick();
        _gridCellsView.Grid.InitMines();
        _gridCellsView.Grid.InitGrid();
    }
}