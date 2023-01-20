using System;
using UnityEngine;




public partial class GridCells 
{
    private readonly GameField _gameField;
    //private readonly IMineView _prefabMineView;
    private readonly int _countColumns;
    private readonly int _countRows;
    private readonly ICell[,] _cells;
    private readonly int _countMines;
    private readonly int[] _firstIndexes;
    private readonly float _scaleBrick;
    private IDownAction _downAction;
    public int CountFlags { get; private set; }
    public bool IsFirstClick { get; private set; }
    public ICell[,] Cells => _cells;
    public int CountMines { get; private set; }
    public GameField GameField => _gameField;


    public GridCells( GameField gameField, IMineView prefabMineView, float scaleBrick, float scaleHeightGrid )
    {
        _gameField = gameField;
    //    _prefabMineView = prefabMineView;
        _scaleBrick = scaleBrick;
        IsFirstClick = true;
        var widthPerUnit = gameField.GetSizePerUnit(_scaleBrick, _scaleBrick / scaleHeightGrid);
        _countColumns = Mathf.RoundToInt( widthPerUnit.x );
        if (_countColumns > widthPerUnit.x) _countColumns--;
        _countRows = Mathf.RoundToInt(widthPerUnit.y);
        var percentMine = 10;
       // _countMines = _countColumns * _countRows * percentMine / 100;
        _cells = new ICell[_countColumns, _countRows];
        _firstIndexes = new int[2] { -1, -1 };
        CreateBlocks();
        CountFlags = _countMines;
    }

    public void ConfirmFirstClick()
    {
        IsFirstClick = false;
    }

    public void FindFirstIndexesOnClick( ICell cell )
    {
        _firstIndexes[0] = cell.CellData.Index1;
        _firstIndexes[1] = cell.CellData.Index2;
        IsFirstClick = false;
    }

    public void GenerateMines()
    {
        for (int j = 0; j < _cells.GetLength(1); j++)
        {
            var indexRandom = UnityEngine.Random.Range(0, _cells.GetLength(0));
            var maxIteration = 100000;
            var iteration = 0;
            while (DeniedSetMines(indexRandom, j) && iteration < maxIteration)
            {
                indexRandom = UnityEngine.Random.Range(0, _cells.GetLength(0));
                iteration++;
            }
            _cells[indexRandom, j].CreateMine( -1, indexRandom, j);
            CountMines++;
        }

        CountFlags = CountMines;
        _gameField.DisplayCountMines(CountMines);
    }


    private bool DeniedSetMines( int i, int j )
    {
        bool result = true;
            if ( 
                 ( (i > _firstIndexes[0] + 1 || i < _firstIndexes[0] - 1 ) ||
                   (j > _firstIndexes[1] + 1 || j < _firstIndexes[1] - 1)
                 )
              )
            {
                result = result & false;
            }
            else
            {
                result = result & true;
            }
        return result;
    }
    

    private void CreateBlocks()
    {
            var camera = _gameField.CameraField ?? throw new NullReferenceException("Camera is null");;
            var resolutionCanvas = _gameField.ScreenAdjusment.ResolutionCanvas;
            var heightSprite = _gameField.SpriteData.Height * _scaleBrick;
            var widthSprite = _gameField.SpriteData.Width * _scaleBrick;
            var tabLeftForSprite = (resolutionCanvas.x - (float)_countColumns * widthSprite) / 2f;
            var tabTopForSprite = resolutionCanvas.y * 0.01f;
            var positionStart = camera.ScreenToWorldPoint(new Vector3(tabLeftForSprite + widthSprite/2f, 
                tabTopForSprite + heightSprite/2f) );
        
            for( var i = 0 ; i < _countColumns ; i++ )
            for (var j = 0; j < _countRows; j++)
            {
                var cellData = new CellData(i, j, _scaleBrick);
                var factoryViewCell = new FactoryCellView( _gameField.PrefabCellView, _gameField.PrefabBrickView, cellData, _gameField.transform );
                var factoryCell = new FactoryCell(factoryViewCell, cellData );
                _cells[i, j] = factoryCell.Create();
                _cells[i, j].GetInputHandler().OnClickCell += ReadInputClick;
                _cells[i,j].Display( positionStart, _scaleBrick);
            }
    }
    
    public void InitGrid()
    {
        for( var i = 0 ; i < _countColumns; i++ )
        for( var j = 0; j < _countRows; j++)
        {
             if( _cells[i, j].Value != -1 )
             {
                for( int n = -1; n < 2 ; n++ )
                for( int m = -1; m < 2; m++ )
                {
                   if ( i + n >= 0 && j + m >= 0 &&
                        i + n <= _cells.GetLength(0)-1 &&
                        j + m <= _cells.GetLength(1)-1 &&
                        _cells[i + n, j + m].Value == -1 )
                   {
                       _cells[i,j].IncrementValue();
                   }
                }
             }
        }
    }

    private void ReadInputClick(InputHandler inputHandler)
    {
        if (_gameField.GameState.Game.IsRun == false) return;
        if (inputHandler.IsTimeShort())
        {
            if (inputHandler.transform.TryGetComponent(out CellView viewCell) == false) return;
            if (viewCell.transform.parent.TryGetComponent(out GameField gridView) == false) return;

            _downAction = new DigDownAction(this);

            if (_gameField.ButtonMode.Mode == ButtonMode.Flag)
            {
                _downAction = new FlagDownAction(this);
            }

            if (IsFirstClick) viewCell.InitAction(this, new FirstDigDownAction(gridView));

            if (viewCell.InitAction(this, _downAction) == false)
            {
                _gameField.GameState.StopGame();
                _gameField.GameState.UI.ForEach(ui => ui.Lose());
            }
        }
        else
        {
            if (_gameField.GameState.Game.IsRun == true)
            {
                if (inputHandler.transform.TryGetComponent(out CellView viewCell) == false) return;
                if (viewCell.transform.parent.TryGetComponent(out GameField gridView) == false) return;

                _downAction = new FlagDownAction(this);
                if (_gameField.GameState.GameField.ButtonMode.Mode == ButtonMode.Flag)
                {
                    _downAction = new DigDownAction(this);
                }

                viewCell.InitAction(this, _downAction);
            }
        }
    }

    public bool TryOpen( ICell cell )
    {
        if (cell.IsOpen == true || cell.IsFlagged ) return true;

        cell.Open();

        BrickView brickView = null;
        MineView mineView = null;
        foreach (Transform child in cell.CellView.transform)
        {
            if( child.TryGetComponent(out BrickView view1))
              brickView = child.GetComponent<BrickView>();
            if( child.TryGetComponent(out MineView view2))
                mineView = child.GetComponent<MineView>(); 
        }
        
        
        brickView.transform.gameObject.SetActive(false);
        var parentCanvas = cell.CellView.transform.parent;
        
        if( cell.Value == 0 )
        {
            var index1 = cell.CellData.Index1;
            var index2 = cell.CellData.Index2;
            FindNeighbourEmptyCellsAndOpen(_cells, index1, index2);
        }
        else if (cell.Value == -1)
        {
            mineView.ActivateMine(cell.CellView.transform);
            return false;
        }

        return true;
    }
    
    
    private void FindNeighbourEmptyCellsAndOpen( ICell [,] cells, int index1, int index2 )
    {
        for( int n = -1; n < 2 ; n++ )
        for( int m = -1; m < 2; m++ )
        {
            if ( index1 + n >= 0 && index2 + m >= 0 &&
                 index1 + n <= cells.GetLength(0)-1 &&
                 index2 + m <= cells.GetLength(1)-1 &&
                 cells[index1 + n, index2 + m].Value == 0 )
            {
                TryOpen(cells[index1 + n, index2 + m]);
                FindNeighbourWithoutMineCellsAndOpen(cells, index1 + n, index2 + m);
            }
        }
    }

    private void FindNeighbourWithoutMineCellsAndOpen( ICell [,] cells, int index1, int index2 )
    {
        for( int n = -1; n < 2 ; n++ )
        for( int m = -1; m < 2; m++ )
        {
            if ( index1 + n >= 0 && index2 + m >= 0 &&
                 index1 + n <= cells.GetLength(0)-1 &&
                 index2 + m <= cells.GetLength(1)-1 &&
                 cells[index1 + n, index2 + m].Value > 0)
            {
                if (cells[index1 + n, index2 + m].Value > 0)
                    TryOpen(cells[index1 + n, index2 + m]);
            }
        }
    }

    public void  SetCountFlags( int value )
    {
        if (CountFlags-value > 0)
        {
            CountFlags+=value;
        }
    }
    
    public ICell[,] GetCells() => _cells;


}
