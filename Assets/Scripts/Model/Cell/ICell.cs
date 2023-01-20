using UnityEngine;
public interface ICell
{
    public int Value { get; }
    public CellData CellData { get; }
    public bool TryOpen();
    public bool SetFlag();
    public void IncrementValue();
    public void CreateMine( int valueCell, int i, int j);
    public void Display( Vector3 positionStart, float scale);
    public Transform TransformView { get; }
    public InputHandler GetInputHandler();


}
