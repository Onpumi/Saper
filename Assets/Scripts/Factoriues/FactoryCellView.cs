
using UnityEngine;
using Object = UnityEngine.Object;

public class FactoryCellView  : IFactoryView<CellView>
{
    private readonly CellView _prefabCellView;
    private readonly BrickView _prefabBrickView;
    private readonly Transform _parent;
    private readonly CellData _cellData;

    public FactoryCellView(CellView prefabCellView, BrickView prefabBrickView, CellData cellData, Transform parent)
    {
        _prefabCellView = prefabCellView;
        _prefabBrickView = prefabBrickView;
        _parent = parent;
        _cellData = cellData;
    }
    public CellView Create()
    {
        CellView cellView = Object.Instantiate(_prefabCellView, _parent);
        cellView.InitCellData( _cellData );
        var viewBrick = Object.Instantiate(_prefabBrickView, cellView.transform);
        viewBrick.transform.localScale = Vector3.one;
        return cellView;
    }

    
}
