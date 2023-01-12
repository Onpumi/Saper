using UnityEngine;

public class SpawnerObject<T>: ISpawner<T> where T : MonoBehaviour

{
    private Transform _parent;
    public T ObjectView { get; private set; }
    public SpawnerObject( Transform parent )
    {
        _parent = parent;
    }
    public T InstantiateObject( T prefabView, Vector3 scale )
    {
        ObjectView = Object.Instantiate( prefabView, _parent);
        ObjectView.transform.localScale = scale;
        return ObjectView;
    }
}
