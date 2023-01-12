using UnityEngine;

public interface IFactory<T> where T : MonoBehaviour
{
    public T[] ViewObjects { get; }
    public T Create();
    public T[] CreateAll(  int size );
}