
using UnityEngine;
using Object = UnityEngine.Object;

public class FactoryViewCell  : IFactoryView<ViewCell>
{
    private readonly ViewCell _prefabView;
    private readonly ViewBrick _prefabViewBrick;
    private readonly Transform _parent;
    private readonly CellData _cellData;

    public FactoryViewCell(ViewCell prefabView, ViewBrick prefabViewBrick, CellData cellData, Transform parent)
    {
        _prefabView = prefabView;
        _prefabViewBrick = prefabViewBrick;
        _parent = parent;
        _cellData = cellData;
    }
    public ViewCell Create()
    {
        ViewCell view = Object.Instantiate(_prefabView, _parent);
        view.InitCellData( _cellData );
        var viewBrick = Object.Instantiate(_prefabViewBrick, view.transform);
        viewBrick.transform.localScale = Vector3.one;
        return view;
    }

    
}
