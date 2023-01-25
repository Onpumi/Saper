
using UnityEngine;
using Object = UnityEngine.Object;

public class FactoryCellView  : IFactoryView<ICellView>
{
    private readonly ICellView _prefabCellView;
    private readonly IBrickView _prefabBrickView;
    private readonly IMineView _prefabMineView;
    private readonly IFlagView _prefabFlagView;
    private readonly Transform _parent;
    private readonly CellData _cellData;

    public FactoryCellView(ICellView prefabCellView, IFlagView prefabFlagView, IMineView prefabMineView, IBrickView prefabBrickView, CellData cellData, Transform parent)
    {
        _prefabCellView = prefabCellView;
        _prefabBrickView = prefabBrickView;
        _prefabMineView = prefabMineView;
        _prefabFlagView = prefabFlagView;
        _parent = parent;
        _cellData = cellData;
    }
    public ICellView Create()
    {
        var cellView = Object.Instantiate(_prefabCellView.GetTransform(), _parent);
        var brickView = Object.Instantiate(_prefabBrickView.GetTransform(), cellView.transform);
        var mineView = Object.Instantiate(_prefabMineView.GetTransform(), cellView.transform);
        
        brickView.transform.localScale = Vector3.one;
        var flagView = Object.Instantiate(_prefabFlagView.GetTransform(), brickView.transform);
        ICellView CellView = cellView.GetComponent<CellView>();
        CellView.Init( mineView.GetComponent<MineView>(), flagView.GetComponent<FlagView>(), brickView.GetComponent<BrickView>(), _cellData );
        return CellView;
    }

    
}
