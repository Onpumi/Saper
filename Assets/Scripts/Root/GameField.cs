using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameField : SerializedMonoBehaviour, IGameField
{
    [SerializeField] private UIData _uiData;
    [SerializeField] private Views _views;
    [SerializeField] private GameState _gameState;
    [SerializeField] private float _needCountBricks = 10f;
    [SerializeField] private float _scaleHeightGrid = 0.5f;
    [SerializeField] private Sounds _sounds;
    [SerializeField] private List<IUI> _notActiveListBeforeStartUI;
    public int PercentMine { get; private set; }
    public float NeedCountBricks => _needCountBricks;
    public DataSetting DataSetting { get; private set;  }
    public UIData UIData => _uiData;
    public Views Views => _views;
    public float ScaleBrick { get; private set; }
    public float ScaleHeightGrid => _scaleHeightGrid;
    private FieldCells _field;
    public ScreenAdjusment ScreenAdjusment { get; private set; }
    public SpriteData SpriteData { get; private set; }
    public List<IUI> NotActiveListBeforeStartUI => _notActiveListBeforeStartUI;
    public GameState GameState => _gameState;
    public Sounds Sounds => _sounds;
    public Camera CameraField => Camera.main;
    public IGame Game { get; private set; }

     private void Init( )
    {
        ScreenAdjusment = new ScreenAdjusment(transform);
        var width = _views.CellView.GetWidth();
        var height = _views.CellView.GetHeight();
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
                    
        }
    }

    private void Start()
    {
        Init();
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

    public void SaveScaleValueBricks( TypesOption typeOption, UIScalingBlocks uiScalingBlocks )
    {
         if(typeOption == TypesOption.SizeCells)
         {
            DataSetting.GameData.SetupOptionValue(TypesOption.SizeCells, uiScalingBlocks.ScaleBricks);
            ScaleBrick = DataSetting.GameData.GetOptionValue(TypesOption.SizeCells);
         }
    }

    public void ReloadField(  )
    {
        GameState.StopGame();
        GameState.ResetTimeView();
        ScaleBrick = DataSetting.GameData.GetOptionValue(TypesOption.SizeCells);
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
        _uiData.WindowWinner.Hide();
        _notActiveListBeforeStartUI.ForEach(ui => ui.Hide());
    }

    public void ActivateWindowsWin() => _uiData.WindowWinner.Display();
    

    public void DisplayCountMines( int countMines )
    {
        _uiData.UICountMines.Display( countMines );
    }
 

}
