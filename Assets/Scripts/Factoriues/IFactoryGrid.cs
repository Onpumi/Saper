using UnityEngine;

  public interface IFactoryGrid<out T> where T: MonoBehaviour
  {
      public T[] Creates();
  }
