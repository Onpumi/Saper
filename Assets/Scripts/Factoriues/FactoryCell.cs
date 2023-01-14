using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCell : IFactoryCell
{
    private ICell _cell;
    private FactoryViewCell _factoryViewCell;
    private CellData _cellData;
    public FactoryCell( FactoryViewCell factoryViewCell, CellData cellData)
    {
        _factoryViewCell = factoryViewCell;
        _cellData = cellData;
    }
    
    public ICell Create()
    {
        _cell = new Cell(_factoryViewCell.Create(),_cellData.Index1, _cellData.Index2 );
        return _cell;
    }
}
