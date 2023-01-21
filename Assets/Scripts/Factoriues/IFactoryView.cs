using UnityEngine;

public interface IFactoryView<T> 
{
    public T Create();
}