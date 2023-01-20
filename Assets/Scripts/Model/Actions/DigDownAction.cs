using System;
using UnityEngine;

public class DigDownAction : IDownAction
{
    private readonly IGameField _gridCellsView;
    public bool IsLosing { get; private set; }

    public DigDownAction( IGameField gridCellsView )
    {
        _gridCellsView = gridCellsView ?? throw new ArgumentNullException("Grid Cells can't be null");
    }

    public bool Select( ICell cell )
    {
        var grid = _gridCellsView.Grid;

        return cell.TryOpen();


    }
}
