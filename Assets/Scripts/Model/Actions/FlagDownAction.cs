

public class FlagDownAction : IDownAction
{
    private readonly FieldCells _fieldCells;
    private readonly ContainerMines _containerMines;

    public FlagDownAction(FieldCells fieldCells, ContainerMines containerMines )
    {
        _fieldCells = fieldCells;
        _containerMines = containerMines;
    }

      public bool Select( ICell cell )
    {
        if (_containerMines == null || _containerMines.CountMines == 0) return false;
        var result = cell.SetFlag(_containerMines);
        if( result ) _fieldCells.IncrementFlagCount();
        _fieldCells.GameField.DisplayCountMines(_containerMines.CountFlags);
        _fieldCells.GameField.Sounds.PlayAudio(SoundType.Flag);
        
        if (_fieldCells.isWin())
        {
            _fieldCells.GameField.GameState.StopGame();
            _fieldCells.OpenAll();
            _fieldCells.GameField.ActivateWindowsWin();
        }
        return result;
    }

}