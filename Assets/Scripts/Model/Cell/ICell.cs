using UnityEngine;
public interface ICell
{
    public int Value { get; }
    public bool IsOpen { get;  }
    public bool IsFlagged { get;  }
    public void Open();
    public CellData CellData { get; }
    public CellView CellView { get;  }
    public bool SetFlag();
    public void IncrementValue();
    public void CreateMine( int valueCell, int i, int j);
    public void Display( Vector3 positionStart, float scale);
    public InputHandler GetInputHandler();


}
