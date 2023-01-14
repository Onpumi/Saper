using UnityEngine;

  public interface IFactoryGrid<T> where T: MonoBehaviour
  {
      public T[] Creates();
  }
