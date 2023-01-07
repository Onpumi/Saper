
using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class GridCells<T>  where T : Object
{
    private readonly T _prefabView;
    private Transform _parent;
    private readonly int _countColumns;
    private readonly int _countRows;
    private readonly Cell[,] _cells;
    private readonly int _countMines = 3;
    private int[] _arrayMines;
    private int[] _firstIndexes;
    private const float Scale = 0.5f;
    private ViewBrick _childBrick;
    public bool IsFirstClick { get; private set; }
    public ViewCell[] ViewCells { get; private set;  }  
    public Cell[,] Cells => _cells;
    public GridCells(  int countRows, int countColumns, T prefabView, Transform parent )
    {
        _countColumns = countColumns;
        _countRows = countRows;
        _prefabView = prefabView;
        _parent = parent;
        IsFirstClick = true;
        
        if ( countColumns <= 0 || countRows <= 0 )
        {
            throw new ArgumentException("value count columns or count rows is not correct!");
        }

        _cells = new Cell[_countRows, _countColumns];
        ViewCells = new ViewCell[_countRows * _countColumns];
        _firstIndexes = new int[2] { -1, -1 };
        InitBlocks();
        InitBricks();
    }

    public void Init( GameObject firstGameObject)
    {
        FindFirstIndexesOnClick( firstGameObject );
        InitMines( firstGameObject );
        InitGrid();
    }

    public void ConfirmFirstClick()
    {
        IsFirstClick = false;
    }
    
    private void InitBricks()
    {
        int indexCell = 0;
        for( var i = 0 ; i < _countRows ; i++ )
        for( var j = 0; j < _countColumns; j++ )
        {
           _cells[i,j].InitBrick(i, j);
            ViewCells[indexCell].CellInput(_cells[i,j]);
            indexCell++;
        }
    }

    private void InitMines( GameObject firstGameObject )
    {
        GenerateArrayMines();
        int indexMine = 0;
        int indexCell = 0;
        
        for( var i = 0 ; i < _countRows ; i++ )
        for( var j = 0; j < _countColumns; j++ )
        {
            int valueCell;
            valueCell =    _arrayMines[indexMine++];
            if (i != _firstIndexes[0] && j != _firstIndexes[1])
            {
                _cells[i, j].InitMine(valueCell, i, j);
            }
            else if(i == _firstIndexes[0] && j == _firstIndexes[1])
            {
                //Debug.Log($"если нажали эту то мину не ставим {_firstIndexes[0]} {_firstIndexes[1]}");
            }
            ViewCells[indexCell].CellInput(_cells[i,j]);
            indexCell++;
        }
    }


    private void FindFirstIndexesOnClick( GameObject firstGameObject )
    {
        _firstIndexes[0] = firstGameObject.transform.parent.GetComponent<ViewCell>().Cell.Indexes[0];
        _firstIndexes[1] = firstGameObject.transform.parent.GetComponent<ViewCell>().Cell.Indexes[1];
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

    private void InitBlocks()
    {
        var startPosition = Camera.main.ScreenToWorldPoint( new Vector3(20f,50f, 0f) );
        CanvasScaler canvasScaler = _parent.gameObject.GetComponent<CanvasScaler>();
        var referencePixelsPerUnit = canvasScaler.referencePixelsPerUnit;
        var scaleBrick = new Vector3(1 / referencePixelsPerUnit, 1 / referencePixelsPerUnit) * Scale;
        int indexCell = 0;
        
        for( var i = 0 ; i < _countRows ; i++ )
        for (var j = 0; j < _countColumns; j++)
        {
              ViewCells[indexCell] = Object.Instantiate(_prefabView, startPosition, Quaternion.identity) as ViewCell;
              ViewCells[indexCell].transform.localScale = scaleBrick;
              ViewCells[indexCell].transform.SetParent( _parent );
              var widthSprite = ViewCells[indexCell].GetComponent<Image>().sprite.rect.width;
              var heightSprite = ViewCells[indexCell].GetComponent<Image>().sprite.rect.height;
              var position = startPosition;
              var deltaX = scaleBrick.x * widthSprite;
              var deltaY = scaleBrick.y * heightSprite;
              var _tabX = deltaX / 15f;  
              var _tabY = deltaY / 15f;
            
            ViewCells[indexCell].transform.position = new Vector3( position.x + deltaX/2f + deltaX * (i + i*_tabX), 
                                                                 position.y + deltaY * (j + j*_tabY), 0f);
            _cells[i, j] = new Cell(ViewCells[indexCell], _parent);
            indexCell++;
        }
        
    }
    
    private void InitGrid()
    {
        for( var i = 0 ; i < _countRows; i++ )
        for( var j = 0; j < _countColumns; j++)
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

    public Cell[,] GetCells() => _cells;


}
