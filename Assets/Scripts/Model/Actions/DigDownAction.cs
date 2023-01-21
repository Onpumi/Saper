using System;
using UnityEngine;

public class DigDownAction : IDownAction
{
    private readonly IGameField _gridCellsView;
    private readonly FieldCells _fieldCells;
    public bool IsLosing { get; private set; }

    public DigDownAction( FieldCells fieldCells )
    {
        _fieldCells = fieldCells;
    }

    public bool Select( ICell cell )
    {
        return _fieldCells.TryOpen( cell );
    }
}
