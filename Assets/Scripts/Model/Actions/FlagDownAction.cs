using System;
using UnityEngine;

public class FlagDownAction : IDownAction
{
    private GridCells _gridCells;

    public FlagDownAction(GridCells gridCells)
    {
        _gridCells = gridCells;
    }

    public bool Select( ICell cell )
    {
        //if (_gridCells.CountFlags == 0) return false;
        var flag = cell.SetFlag();
        if (flag)
        {
            _gridCells.SetCountFlags(-1);
            _gridCells.GameField.DisplayCountMines(_gridCells.CountFlags);
        }
        else
        {
            _gridCells.SetCountFlags(1);
            _gridCells.GameField.DisplayCountMines(_gridCells.CountFlags);
        }

        return true;
    }

}