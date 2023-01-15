using System;
using UnityEngine;

public class FirstDigDownAction : IDownAction
{
    private readonly IGameField _gridCellsView;

    public FirstDigDownAction( IGameField gridCellsView )
    {
        _gridCellsView = gridCellsView ?? throw new ArgumentNullException("Grid Cells can't be null");
    }

    public bool Select( ICell cell )
    {
        _gridCellsView.Grid.FindFirstIndexesOnClick( cell );
        _gridCellsView.Grid.ConfirmFirstClick();
        _gridCellsView.Grid.GenerateMines();
        _gridCellsView.Grid.InitGrid();
        return true;
    }
}