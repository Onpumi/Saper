using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class GameField : SerializedMonoBehaviour, IGameField
{
    [SerializeField] private ControllerButtonMode _buttonMode;
    [SerializeField] private Views _views;
    [SerializeField] private UICountMines _uiCountMines;
    [SerializeField] private GameState _gameState;
    public CellView PrefabCellView { get; private set; }
    public BrickView PrefabBrickView { get; private set; }
    private MineView _prefabMineView;
    [SerializeField] private float _needCountBricks = 150f;
    [SerializeField] private float _scaleHeightGrid = 0.5f;
    private float _scaleBrick = 1f;
    private GridCells _grid;
    private CellView[] _viewCells;
    public ScreenAdjusment ScreenAdjusment { get; private set; }
    public SpriteData SpriteData { get; private set; }
    private FactoryCell _factoryCell;
    public Vector2 SizePerUnit { get; private set; }
    public GridCells Grid => _grid;
    public ControllerButtonMode ButtonMode => _buttonMode;
    public GameState GameState => _gameState;

    public Camera CameraField
    {
        get => Camera.main;
    }
    public IGame Game { get; private set; }
    public float Scale => _scaleBrick;


    public void Init(CellView cellView, BrickView brickView, MineView mineView)
    {
        PrefabCellView = cellView;
        PrefabBrickView = brickView;
        _prefabMineView = mineView;
        ScreenAdjusment = new ScreenAdjusment(transform);
        var width = PrefabCellView.GetComponent<Image>().sprite.rect.width;
        var height = PrefabCellView.GetComponent<Image>().sprite.rect.height;
        SpriteData = new SpriteData(width, height);
        CalculateScale();
    }

    private void Start()
    {
        Game = new GameRunning();
        _grid = new GridCells(this, _views.MineView, _scaleBrick, _scaleHeightGrid);
    }

       private void CalculateScale()
    { 
        _needCountBricks = 150f;
        var screenArea = ScreenAdjusment.ResolutionCanvas.x * ScreenAdjusment.ResolutionCanvas.y;
        var spriteArea = SpriteData.Width * SpriteData.Height;
        var deltaScale = Mathf.Sqrt(screenArea / (_needCountBricks * spriteArea));
        _scaleBrick *= deltaScale;
    }
    
    public Vector2 GetSizePerUnit( float scaleX, float scaleY )
    {
        var resolutionCanvas = ScreenAdjusment.ResolutionCanvas;
        var refPixelsPerUnit = ScreenAdjusment.RefPixelsPerUnit;
        return  SizePerUnit = new Vector2( resolutionCanvas.x / (refPixelsPerUnit * scaleX), 
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
        
        _grid = new GridCells(this, _views.MineView, _scaleBrick, _scaleHeightGrid);

    }


    public void DisplayCountMines( int countMines )
    {
        _uiCountMines.Display( countMines );
    }
    
 /*   
    public void CreateCells( ICell[,] cells, int countColumns, int countRows, float scale )
    {
        var camera = Camera.main ?? throw new NullReferenceException("Camera is null");;
        var resolutionCanvas = ScreenAdjusment.ResolutionCanvas;
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
            var factoryViewCell = new FactoryCellView( PrefabCellView, PrefabBrickView, cellData, transform );
            var factoryCell = new FactoryCell(factoryViewCell, cellData );
            cells[i, j] = factoryCell.Create();
            cells[i, j].GetInputHandler().OnDigCell += delegate {  };
            cells[i,j].Display( positionStart, scale);
        }
    }
*/


}
