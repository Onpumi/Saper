using System;
using UnityEngine;

public class FlagDownAction : IDownAction
{
    private GridCells _gridCells;

    public FlagDownAction(GridCells gridCells)
    {
        _gridCells = gridCells;
    }

      public bool Select( GridCells gridCells, ICell cell )
    {
        var flag = cell.SetFlag();
        if (flag)
        {
            if (_gridCells.CountFlags == 0) return false;
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