using UnityEngine;

public class FactoryMine : IFactoryMine
{
    private ICell _cell;
    private FactoryMineView _factoryMineView;
    private CellData _cellData;
    public FactoryMine( FactoryMineView factoryMineView, CellData cellData)
    {
        _factoryMineView = factoryMineView;
        _cellData = cellData;
    }
    
    public ICell Create()
    {
        var viewMine = _factoryMineView.Create();
        _cell = new CellMine( viewMine,_cellData );
        return _cell;
    }
}