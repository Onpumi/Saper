using UnityEngine;
public interface ICell
{
    public int Value { get; }
    public int[] Indexes { get;  }
    public bool IsOpen { get;  }
    public bool IsFlagged { get; }
    public CellData CellData { get; }
    public bool TryOpen();
    public void Open();
    public void Init( int i, int j);
    public void CreateMine(int value, int indexI, int indexJ);
    public void Display(Vector3 position, float scale);
}
