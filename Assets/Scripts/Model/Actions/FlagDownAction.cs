
using UnityEngine;

public class FlagDownAction : IDownAction
{
    private FieldCells _fieldCells;
    private ContainerMines _containerMines;

    public FlagDownAction(FieldCells fieldCells, ContainerMines containerMines )
    {
        _fieldCells = fieldCells;
        _containerMines = containerMines;
    }

      public bool Select( ICell cell )
    {
        if (_containerMines == null || _containerMines.CountMines == 0) return false;
        
        Debug.Log(_containerMines.CountFlags);
        
        var isFlag = cell.SetFlag(_containerMines.CountFlags);

        //if (_containerMines.CountFlags <= 0) return false;
        
        if (isFlag)
        {
            _containerMines.SetCountFlags(-1);
            _fieldCells.GameField.DisplayCountMines(_containerMines.CountFlags);
        }
        else
        {
            _containerMines.SetCountFlags(1);
            _fieldCells.GameField.DisplayCountMines(_containerMines.CountFlags);
        }
        
        
        return true;
    }

}