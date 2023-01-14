using UnityEngine;

public interface IFactoryView<T> where T : MonoBehaviour
{
    public T Create();
}