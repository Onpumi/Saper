using UnityEngine;
using Object = UnityEngine.Object;

public class FactoryMineView  : IFactoryView<MineView>
{
    private readonly MineView _prefabMineView;
    private readonly Transform _parent;

    public FactoryMineView(MineView prefabMineView, Transform parent )
    {
        _prefabMineView = prefabMineView;
        _parent = parent;
        
        
    }
    public MineView Create()
    {
        MineView mine = Object.Instantiate(_prefabMineView, _parent);
        //var img = _parent.GetComponent<UnityEngine.UI.Image>();
        //Color color = img.color;
        //color.a = 0.5f;
        //img.color = color;
        mine.transform.localScale = Vector3.one;
        mine.transform.position = _parent.position;
        return mine;
    }

    
}