using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameField : MonoBehaviour, IGameField
{
    [SerializeField] private GameState _gameState;
    private CellView _prefabCellView;
    private BrickView _prefabBrickView;
    private MineView _prefabMineView;
    [SerializeField] private GameState _root;
    [SerializeField] private float _needCountBricks = 150f;
    [SerializeField] private float _scaleHeightGrid = 0.9f;
    private float _scaleBrick = 1f;
    private GridCells _grid;
    private CellView[] _viewCells;
    private ScreenAdjusment _screenAdjusment;
    private SpriteData SpriteData;
    private FactoryCell _factoryCell;
    public Vector2 SizePerUnit { get; private set; }
    public GridCells Grid => _grid;
    public GameState GameState => _gameState;
    public IGame Game { get; private set;  }

    public float Scale => _scaleBrick;


    

    public void Init ( CellView cellView, BrickView brickView, MineView mineView )
    {
        Game = new GameRunning();    
        _prefabCellView = cellView;
        _prefabBrickView = brickView;
        _prefabMineView = mineView;
        _screenAdjusment = new ScreenAdjusment( transform );
        SpriteData.Width = _prefabCellView.GetComponent<Image>().sprite.rect.width;
        SpriteData.Height = _prefabCellView.GetComponent<Image>().sprite.rect.height;
        CalculateScale();
        _grid = new GridCells(this, _prefabMineView, _scaleBrick, _scaleHeightGrid);

    }


    public void DestroyAll()
    {
        
    }

    private float I = 0f;

    private void CalculateScale()
    {
        var _needCountBricks = 150f;
        var screenArea = _screenAdjusment.ResolutionCanvas.x * _screenAdjusment.ResolutionCanvas.y;
        var spriteArea = SpriteData.Width * SpriteData.Height;
        var deltaScale = Mathf.Sqrt(screenArea / (_needCountBricks * spriteArea));
        _scaleBrick *= deltaScale;
        
    }
    
    public Vector2 GetSizePerUnit( float scaleX, float scaleY )
    {
        var resolutionCanvas = _screenAdjusment.ResolutionCanvas;
        var refPixelsPerUnit = _screenAdjusment.RefPixelsPerUnit;
        return  SizePerUnit = new Vector2( resolutionCanvas.x / (refPixelsPerUnit * scaleX), 
                                           resolutionCanvas.y / (refPixelsPerUnit * scaleY));
    }



    public void DestroyField(  )
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
        
        _grid = new GridCells(this, _prefabMineView, _scaleBrick, _scaleHeightGrid);

    }
    
    public void DisplayCells( ICell[,] cells, int countColumns, int countRows, float scale )
    {
        int indexCell = 0;
        var delta = 0;

        var camera = Camera.main ?? throw new NullReferenceException("Camera is null");;

        var resolutionCanvas = _screenAdjusment.ResolutionCanvas;
        var heightSprite = SpriteData.Height * scale;
        var widthSprite = SpriteData.Width * scale;
        var _tabLeftForSprite = (resolutionCanvas.x - (float)countColumns * widthSprite) / 2f;
        var _tabTopForSprite = resolutionCanvas.y * 0.01f;

        var positionStart = camera.ScreenToWorldPoint(new Vector3(_tabLeftForSprite + widthSprite/2f, 
            _tabTopForSprite + heightSprite/2f) );

        if (_viewCells == null)
        {
            _viewCells = new CellView[countRows * countColumns];
        }

        
        for( var i = 0 ; i < countColumns ; i++ )
        for (var j = 0; j < countRows; j++)
        {
            var cellData = new CellData(i, j, scale);
            var factoryViewCell = new FactoryCellView( _prefabCellView, _prefabBrickView, cellData, transform );
            var factoryCell = new FactoryCell(factoryViewCell, cellData );
            cells[i, j] = factoryCell.Create();
            cells[i,j].Display( positionStart, scale);
            indexCell++;
        }
    }



}
