
using UnityEngine;

public interface ISpawner<T> where T : MonoBehaviour
{
    public T ObjectView { get; }
    public T InstantiateObject( T prefabView, Vector3 scale );
}

