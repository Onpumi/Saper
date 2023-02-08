using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameField : SerializedMonoBehaviour, IGameField
{
    [SerializeField] private UIDatas _uiDatas;
    [SerializeField] private ControllerButtonMode _buttonMode;
    [SerializeField] private WindowsWinner _windowsWinner;
    [SerializeField] private Views _views;
    [SerializeField] private UICountMines _uiCountMines;
    [SerializeField] private GameState _gameState;
    [SerializeField] private float _needCountBricks = 10f;
    [SerializeField] private float _scaleHeightGrid = 0.5f;
    [SerializeField] private Sounds _sounds;
    [SerializeField] private List<IUI> _notActiveListBeforeStartUI;
    public int PercentMine { get; private set; }
    public float NeedCountBricks => _needCountBricks;
    public DataSetting DataSetting { get; private set;  }
    public UIDatas UIDatas => _uiDatas;
    public ICellView PrefabCellView { get; private set; }
    public IBrickView PrefabBrickView { get; private set; }
    public IMineView PrefabMineView { get; private set; }
    public IFlagView PrefabFlagView { get; private set; }
    public float ScaleBrick { get; private set; }
    public float ScaleHeightGrid => _scaleHeightGrid;
    private FieldCells _field;
    public ScreenAdjusment ScreenAdjusment { get; private set; }
    public SpriteData SpriteData { get; private set; }
    public List<IUI> NotActiveListBeforeStartUI => _notActiveListBeforeStartUI;
    public ControllerButtonMode ButtonMode => _buttonMode;
    public GameState GameState => _gameState;
    public Sounds Sounds => _sounds;

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
        DataSetting = new DataSetting( this );
        ScaleBrick = DataSetting.GameData.GetOptionValue(TypesOption.SizeCells);
        SetPercentMine((TypesGame)DataSetting.GameData.GetDifficultValue());
    }

    public void SetPercentMine(TypesGame typesGame)
    {
        switch (typesGame)
        {
            case TypesGame.DifficultGame : PercentMine = 20;
                break;
            case TypesGame.MediumGame : PercentMine = 15;
                break;
            case TypesGame.EasyGame : PercentMine = 10;
                break;
                default:
                    throw new ArgumentException("TypesGame is wrong value!");
                    break;
        }
    }

    private void Start()
    {
        Init( _views.CellView, _views.FlagView, _views.MineView, _views.BrickView );
        _field = new FieldCells(this, ScaleBrick, _scaleHeightGrid);
    }

    public float CalculateScale()
    {
       var scaleBrick = 1f;
       var screenArea = ScreenAdjusment.ResolutionCanvas.x * ScreenAdjusment.ResolutionCanvas.y;
       var spriteArea = SpriteData.Width * SpriteData.Height;
       var deltaScale = Mathf.Sqrt(screenArea / (_needCountBricks * spriteArea));
       scaleBrick *= deltaScale;
       return scaleBrick;
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
        GameState.StopGame();
        GameState.ResetTimeView();
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
        
        _field = new FieldCells(this,  ScaleBrick, _scaleHeightGrid);
        _windowsWinner.Hide(); 
        _notActiveListBeforeStartUI.ForEach(ui => ui.Hide());
        
    }

    public void ActivateWindowsWin() => _windowsWinner.Display();
    

    public void DisplayCountMines( int countMines )
    {
        _uiCountMines.Display( countMines );
    }
 

}
