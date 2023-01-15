using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCell : IFactoryCell
{
    private ICell _cell;
    private FactoryCellView _factoryCellView;
    private CellData _cellData;
    public FactoryCell( FactoryCellView factoryCellView, CellData cellData)
    {
        _factoryCellView = factoryCellView;
        _cellData = cellData;
    }
    
    public ICell Create()
    {
        _cell = new Cell(_factoryCellView.Create(),_cellData.Index1, _cellData.Index2 );
        return _cell;
    }
}
