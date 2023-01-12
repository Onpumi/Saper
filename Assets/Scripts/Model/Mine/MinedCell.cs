public class MinedCell 
{
    public bool IsOpened { get; }
    public bool IsFlagged { get; }
    public CellData Data { get; }

    public MinedCell(CellData data)
    {
        Data = data;
    }
    
    public void Open() { }

}