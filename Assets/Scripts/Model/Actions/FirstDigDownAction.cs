using System;
using UnityEngine;

public class FirstDigDownAction : IDownAction
{
    private readonly FieldCells _fieldCells;
   // private Timer _timer;

    public FirstDigDownAction( FieldCells fieldCells )
    {
        _fieldCells = fieldCells ?? throw new ArgumentNullException("Grid Cells can't be null");
    }

    public bool Select( ICell cell )
    {
        _fieldCells.FindFirstIndexesOnClick(cell);
        _fieldCells.ConfirmFirstClick();
        _fieldCells.GenerateMines();
        _fieldCells.InitGrid();
        return true;
    }
}