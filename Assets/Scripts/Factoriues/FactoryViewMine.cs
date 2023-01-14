using UnityEngine;
using Object = UnityEngine.Object;

public class FactoryViewMine  : IFactoryView<ViewMine>
{
    private readonly ViewMine _prefabViewMine;
    private readonly Transform _parent;

    public FactoryViewMine(ViewMine prefabViewMine, Transform parent)
    {
        _prefabViewMine = prefabViewMine;
        _parent = parent;
    }
    public ViewMine Create()
    {
        ViewMine mine = Object.Instantiate(_prefabViewMine, _parent);
        mine.transform.localScale = Vector3.one;
        mine.transform.position = _parent.position;
        return mine;
    }

    
}