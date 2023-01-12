using UnityEngine;
public interface ICell
{
    public int CountMinesNear { get; }
    public bool IsOpen { get;  }
    public bool IsFlagged { get; }
    public CellData CellData { get; }
    public bool TryOpen();
    public void Open();
    public void SetFlag();
}
