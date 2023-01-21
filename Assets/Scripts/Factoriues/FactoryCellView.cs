
using UnityEngine;
using Object = UnityEngine.Object;

public class FactoryCellView  : IFactoryView<ICellView>
{
    private readonly ICellView _prefabCellView;
    private readonly IBrickView _prefabBrickView;
    private readonly Transform _parent;
    private readonly CellData _cellData;

    public FactoryCellView(ICellView prefabCellView, IBrickView prefabBrickView, CellData cellData, Transform parent)
    {
        _prefabCellView = prefabCellView;
        _prefabBrickView = prefabBrickView;
        _parent = parent;
        _cellData = cellData;
    }
    public ICellView Create()
    {
        var cellView = Object.Instantiate(_prefabCellView.GetTransform(), _parent);
        var viewBrick = Object.Instantiate(_prefabBrickView.GetTransform(), cellView.transform);
        viewBrick.transform.localScale = Vector3.one;
        ICellView CellView = cellView.GetComponent<CellView>();
        CellView.InitCellData( _cellData );
        return CellView;
    }

    
}
