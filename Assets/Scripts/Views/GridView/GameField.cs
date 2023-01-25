using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class GameField : SerializedMonoBehaviour, IGameField
{
    [SerializeField] private ControllerButtonMode _buttonMode;
    [SerializeField] private WindowsWinner _windowsWinner;
    [SerializeField] private Views _views;
    [SerializeField] private UICountMines _uiCountMines;
    [SerializeField] private GameState _gameState;
    [SerializeField] private float _needCountBricks = 150f;
    [SerializeField] private float _scaleHeightGrid = 0.5f;
    [SerializeField] private List<IUI> _notActiveListBeforeStartUI; 
    public ICellView PrefabCellView { get; private set; }
    public IBrickView PrefabBrickView { get; private set; }
    public IMineView PrefabMineView { get; private set; }
    public IFlagView PrefabFlagView { get; private set; }
    private float _scaleBrick = 1f;
    private FieldCells _field;
    public ScreenAdjusment ScreenAdjusment { get; private set; }
    public SpriteData SpriteData { get; private set; }
    public List<IUI> NotActiveListBeforeStartUI => _notActiveListBeforeStartUI;
    public ControllerButtonMode ButtonMode => _buttonMode;
    public GameState GameState => _gameState;

    public Camera CameraField
    {
        get => Camera.main;
    }
    public IGame Game { get; private set; }


    public void Init(ICellView cellView, IFlagView flagView, IMineView mineView, IBrickView brickView)
    {
        PrefabCellView = cellView;
        PrefabBrickView = brickView;
        PrefabMineView = mineView;
        PrefabFlagView = flagView;
        ScreenAdjusment = new ScreenAdjusment(transform);
        var width = PrefabCellView.GetWidth();
        var height = PrefabCellView.GetHeight();

        SpriteData = new SpriteData(width, height);
        CalculateScale();
    }

    private void Start()
    {
        Init( _views.CellView, _views.FlagView, _views.MineView, _views.BrickView );
        Game = new GameRunning();
        _field = new FieldCells(this, _scaleBrick, _scaleHeightGrid);
    }

       private void CalculateScale()
    { 
         _needCountBricks = 140f;
        //_needCountBricks = 30f;
        var screenArea = ScreenAdjusment.ResolutionCanvas.x * ScreenAdjusment.ResolutionCanvas.y;
        var spriteArea = SpriteData.Width * SpriteData.Height;
        var deltaScale = Mathf.Sqrt(screenArea / (_needCountBricks * spriteArea));
        _scaleBrick *= deltaScale;
    }
    
    public Vector2 GetSizePerUnit( float scaleX, float scaleY )
    {
        var resolutionCanvas = ScreenAdjusment.ResolutionCanvas;
        var refPixelsPerUnit = ScreenAdjusment.RefPixelsPerUnit;
        return  new Vector2( resolutionCanvas.x / (refPixelsPerUnit * scaleX), 
                                           resolutionCanvas.y / (refPixelsPerUnit * scaleY));
    }

    public void ReloadField(  )
    {
        foreach (Transform cell in transform)
        {
            if (cell.TryGetComponent(out CellView cellview))
            {
                foreach (Transform child  in cellview.transform )
                {
                    Destroy(cellview.transform.gameObject);
                }
            }
        }
        
        _field = new FieldCells(this,  _scaleBrick, _scaleHeightGrid);
        _windowsWinner.Hide();
        _notActiveListBeforeStartUI.ForEach(ui => ui.Hide());
    }

    public void ActivateWindowsWin() => _windowsWinner.Display();
    

    public void DisplayCountMines( int countMines )
    {
        _uiCountMines.Display( countMines );
    }
 

}
