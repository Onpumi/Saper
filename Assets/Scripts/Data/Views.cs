using UnityEngine;
using Sirenix.OdinInspector;

public  class Views : MonoBehaviour, IViews
{
    [SerializeField] private MineView _mineView;
    [SerializeField] private CellView _cellView;
    [SerializeField] private FlagView _flagView;
    [SerializeField] private BrickView _brickView;
    [SerializeField] private BoomView _boomView;
    [SerializeField] private GameField _gameField;
    public IMineView MineView => _mineView;
    public ICellView CellView => _cellView;
    public IFlagView FlagView => _flagView;
    public IBrickView BrickView => _brickView;
    public IBoomView BoomView => _boomView;
    public IGameField GameField => _gameField;

}
