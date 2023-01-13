
using UnityEngine;

public class GridCells
{
    private readonly GridCellsView _gridCellsView;
    private readonly int _countColumns;
    private readonly int _countRows;
    private readonly Cell[,] _cells;
    private readonly int _countMines;
    private int[] _arrayMines;
    private readonly int[] _firstIndexes;
    private readonly float _scaleBrick;
    public bool IsFirstClick { get; private set; }
    public ICell[,] Cells => _cells;

    public GridCells( GridCellsView gridCellsView, float scaleBrick, float scaleHeightGrid )
    {
        _gridCellsView = gridCellsView;
        _scaleBrick = scaleBrick;
        IsFirstClick = true;
        var widthPerUnit = gridCellsView.GetSizePerUnit(_scaleBrick, _scaleBrick / scaleHeightGrid);
        _countColumns = Mathf.RoundToInt( widthPerUnit.x );
        if (_countColumns > widthPerUnit.x) _countColumns--;
        _countRows = Mathf.RoundToInt(widthPerUnit.y);
        var percentMine = 10;
        _countMines = _countColumns * _countRows * percentMine / 100;
        _cells = new Cell[_countColumns, _countRows];
        _firstIndexes = new int[2] { -1, -1 };
        CreateBlocks();
        InitBricks();
    }

    public void ConfirmFirstClick()
    {
        IsFirstClick = false;
    }
    
    private void InitBricks()
    {
        int indexCell = 0;
        for( var i = 0 ; i < _countColumns ; i++ )
        for( var j = 0; j < _countRows; j++ )
        {
           _cells[i,j].Init(i, j);
            indexCell++;
        }
    }
    
   public void InitMines(  )
    {
        GenerateArrayMines();
        int indexMine = 0;
        int indexCell = 0;
        
        for( var i = 0 ; i < _countColumns ; i++ )
        for( var j = 0; j < _countRows; j++ )
        {
            int valueCell;
            valueCell =    _arrayMines[indexMine++];
                    if ( 
                            i != _firstIndexes[0] && j != _firstIndexes[1] &&
                            i != _firstIndexes[0]-1 && j != _firstIndexes[1] &&
                            i != _firstIndexes[0]+1 && j != _firstIndexes[1] &&
                            i != _firstIndexes[0]+1 && j != _firstIndexes[1]-1 &&
                            i != _firstIndexes[0]+1 && j != _firstIndexes[1]+1 &&
                            i != _firstIndexes[0] && j != _firstIndexes[1]+1 &&
                            i != _firstIndexes[0] && j != _firstIndexes[1]-1 &&
                            i != _firstIndexes[0]-1 && j != _firstIndexes[1]+1
                        )
                    {
                        _cells[i, j].CreateMine(valueCell, i, j);
                    }
            indexCell++;
        }
    }

    public void FindFirstIndexesOnClick( ICell cell )
    {
        _firstIndexes[0] = cell.CellData.Index1;
        _firstIndexes[1] = cell.CellData.Index2;
        IsFirstClick = false;
    }


    private void GenerateArrayMines()
    {
        _arrayMines = new int[_countRows * _countColumns];
        int countMaxIteration = 10000;
        int countIteration = 0;
       
        for ( var i = 0; i < _countMines; i++)
        {
            if (countIteration > countMaxIteration) break;
            var randomIndexMine = UnityEngine.Random.Range(0,_arrayMines.Length-1);
            if( _arrayMines[randomIndexMine] == -1 )
            {
                i--;
                countIteration++;
                continue;
            }
            _arrayMines[randomIndexMine] = -1;
        }
    }

    private void CreateBlocks()
    {
            _gridCellsView.DisplayCells( _cells, _countColumns,_countRows,_scaleBrick);        
    }
    
    public void InitGrid()
    {
        for( var i = 0 ; i < _countColumns; i++ )
        for( var j = 0; j < _countRows; j++)
        {
             if( _cells[i, j].CountMinesNear != -1 )
             {
                for( int n = -1; n < 2 ; n++ )
                for( int m = -1; m < 2; m++ )
                {
                   if ( i + n >= 0 && j + m >= 0 &&
                        i + n <= _cells.GetLength(0)-1 &&
                        j + m <= _cells.GetLength(1)-1 &&
                        _cells[i + n, j + m].CountMinesNear == -1 )
                   {
                       _cells[i,j].IncrementValue();
                   }
                }
             }
        }
    }

    public ICell[,] GetCells() => _cells;


}
