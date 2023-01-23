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
        var result = _fieldCells.TryOpen( cell );
        if (_fieldCells.isWin() && cell.IsInitMine == false )
        {
            _fieldCells.GameField.GameState.StopGame();
            _fieldCells.GameField.ActivateWindowsWin();
        }
        return result;
    }
}
