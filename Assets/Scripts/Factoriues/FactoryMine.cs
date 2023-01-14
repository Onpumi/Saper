using UnityEngine;

public class FactoryMine : IFactoryMine
{
    private ICell _cell;
    private FactoryViewMine _factoryViewMine;
    private CellData _cellData;
    public FactoryMine( FactoryViewMine factoryViewMine, CellData cellData)
    {
        _factoryViewMine = factoryViewMine;
        _cellData = cellData;
    }
    
    public ICell Create()
    {
        var viewMine = _factoryViewMine.Create();
        _cell = new CellMine( viewMine,_cellData );
        return _cell;
    }
}