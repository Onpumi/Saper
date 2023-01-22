
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
        
        
        bool isFlag = false;
        isFlag= cell.SetFlag(_containerMines);
        _fieldCells.GameField.DisplayCountMines(_containerMines.CountFlags);
        return true;
    }

}