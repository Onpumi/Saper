
public class DigDownAction : IDownAction
{
    private readonly IGameField _gridCellsView;
    private readonly FieldCells _fieldCells;

    public DigDownAction( FieldCells fieldCells )
    {
        _fieldCells = fieldCells;
    }

    public bool Select( ICell cell )
    {
        var result = _fieldCells.TryOpen( cell );
        if ( result == false || (_fieldCells.isWin() && cell.IsInitMine == false) ) StopGame( cell );
        return result;
    }

    public void StopGame( ICell cell )
    {
        _fieldCells.GameField.GameState.StopGame();
        _fieldCells.GameField.GameState.UI.ForEach(ui => ui.Lose());
        _fieldCells.OpenAll();
        _fieldCells.Reset();
        if (_fieldCells.isWin() && cell.IsInitMine == false ) _fieldCells.GameField.ActivateWindowsWin();
    }
}
