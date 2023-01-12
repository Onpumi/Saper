
using UnityEngine;
using Object = UnityEngine.Object;

public class FactoryViews<T>  : IFactory<T> where T : MonoBehaviour 
{
    private readonly T _prefabView;
    private readonly Transform _parent;
    public T[] ViewObjects { get; private set;  }

    public FactoryViews(T prefabView, Transform parent)
    {
        _prefabView = prefabView;
        _parent = parent;
    }
    public T Create()
    {
        T newGameObject = Object.Instantiate(_prefabView, _parent);
        return newGameObject;
    }

    public T[] CreateAll(  int size)
    {
        if (ViewObjects is null)
        {
            ViewObjects = new T[size];
        }

        for( int i = 0 ; i < size ; i++)
        {
            ViewObjects[i] = Create();
        }
        
        return ViewObjects;
    }
}
