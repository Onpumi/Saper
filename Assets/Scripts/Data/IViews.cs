

public interface IViews
{
    public IMineView MineView { get; }
    public ICellView CellView { get;  }
    public IBrickView BrickView { get; }
    public IBoomView BoomView { get;  }
    public IFlagView FlagView { get; }
    public IGameField GameField { get; }
}
