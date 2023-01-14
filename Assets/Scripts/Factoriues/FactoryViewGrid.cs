using UnityEngine;
using System.Collections.Generic;
using Sirenix.Utilities;

/*
public class FactoryViewGrid<T> : IFactoryGrid<T> where T : MonoBehaviour
{
    private readonly List<T> _prefabViews;
    private readonly FactoryViewCell<ViewCell> _factory;
    private readonly int _size;
    public FactoryViewGrid(T prefabView, int size, Transform parent )
    {
        _factory = new FactoryViewCell<ViewCell>( prefabView, parent);
        _prefabViews = new List<T>();
        _size = size;
    }

    public T[] Creates()
    {
        for( int i = 0 ; i < _size ; i++ )
          _prefabViews.Add(_factory.Create());
        return _prefabViews.ToArray();
    }

}
*/