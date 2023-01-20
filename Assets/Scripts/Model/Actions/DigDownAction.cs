using System;
using UnityEngine;

public class DigDownAction : IDownAction
{
    private readonly IGameField _gridCellsView;
    private readonly GridCells _gridCells;
    public bool IsLosing { get; private set; }

    //public DigDownAction( IGameField gridCellsView )
    public DigDownAction( GridCells gridCells )
    {
        _gridCells = gridCells;
        //    _gridCellsView = gridCellsView ?? throw new ArgumentNullException("Grid Cells can't be null");
    }

    public bool Select( GridCells gridCells, ICell cell )
    {
//        var grid = _gridCellsView.Grid;
  //      return cell.TryOpen();
     
        return gridCells.TryOpen( cell );

    }
}
