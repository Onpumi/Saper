
using UnityEngine;

public interface ICellView : IView
{
    public MineView MineView { get; }
    public FlagView FlagView { get;  }
    public BrickView BrickView { get; }
    public void Display(ICell cell, Vector3 positionStart, float scale );
    public void Init(MineView mineView, FlagView flagView,BrickView brickView, CellData cellData);
    public CellData GetCellData();
    public InputHandler GetInput( );
    public void SetTextNumbers(int value);
    public bool InitFlag( bool value );
    public bool GetFlag();

}
