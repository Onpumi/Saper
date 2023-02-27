using UnityEngine;

public class Factory<T> : IFactory<T> where T : Object
{
    private T _view;
    private readonly Transform _parent;

    public Factory( T prefabView, Transform parent )
    {
        _view = prefabView;
        _parent = parent;
    }
    
    public T Create()
    {
        return _view = Object.Instantiate(_view, _parent);
    }
}