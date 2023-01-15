using UnityEngine;
public interface ICell
{
    public int Value { get; }
    public bool IsOpen { get;  }
    public bool IsFlagged { get; }
    public CellData CellData { get; }
    public bool TryOpen();
    public void Open();
    public void SetFlag();
    public void IncrementValue();
    public void CreateMine( int valueCell, int i, int j);
    public Transform GetViewTransform();
    public void Display( Vector3 positionStart, float scale);
    public ICellView CellView { get; }
    public Transform TransformView { get; }
    
}
