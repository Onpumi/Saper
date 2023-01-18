
using UnityEngine;



public class GridCells 
{
    private readonly GameField _gameField;
    private readonly IMineView _prefabMineView;
    private readonly int _countColumns;
    private readonly int _countRows;
    private ICell[,] _cells;
    private readonly int _countMines;
    private readonly int[] _firstIndexes;
    private readonly float _scaleBrick;
    public int CountFlags { get; private set; }
    public bool IsFirstClick { get; private set; }
    public ICell[,] Cells => _cells;
    public int CountMines { get; private set; }
    public GameField GameField => _gameField;


    public GridCells( GameField gameField, IMineView prefabMineView, float scaleBrick, float scaleHeightGrid )
    {
        _gameField = gameField;
        _prefabMineView = prefabMineView;
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
            var indexRandom = Random.Range(0, _cells.GetLength(0));
            var parent = _cells[indexRandom, j].TransformView;
            var cell = _cells[indexRandom, j];
            var maxIteration = 100000;
            var iteration = 0;
            while (DeniedSetMines(indexRandom, j) && iteration < maxIteration)
            {
                indexRandom = Random.Range(0, _cells.GetLength(0));
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
            _gameField.DisplayCells( _cells, _countColumns,_countRows,_scaleBrick);        
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

    public void  SetCountFlags( int value )
    {
        if (CountFlags-value > 0)
        {
            CountFlags+=value;
        }
    }
    
    public ICell[,] GetCells() => _cells;


}
