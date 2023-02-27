using UnityEngine;
public interface ICell
{
    public int Value { get; }

    public bool IsOpen { get;  }
    public bool IsFlagged { get;  }
    public bool IsInitMine { get; }
    public void Open();
    public CellData CellData { get; }
    public ICellView CellView { get;  }
    public bool SetFlag( ContainerMines containerMines );
    public void IncrementValue();
    public void CreateMine( int valueCell, int i, int j);
    public void Display( Vector3 positionStart, float scale);
    public InputHandler GetInputHandler();

}
