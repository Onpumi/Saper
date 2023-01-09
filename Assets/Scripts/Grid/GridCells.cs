
using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class GridCells<T>  where T : Object
{
    private readonly T _prefabView;
    private readonly Transform _parent;
    private readonly int _countColumns;
    private readonly int _countRows;
    private readonly Cell[,] _cells;
    private readonly int _countMines;
    private int[] _arrayMines;
    private readonly int[] _firstIndexes;
    private const float Scale = 0.5f;
    private readonly float _widthSprite;
    private readonly float _heightSprite;
    private readonly Vector2 _resolutionCanvas;
    public bool IsFirstClick { get; private set; }
    public ViewCell[] ViewCells { get; private set;  }  
    public Cell[,] Cells => _cells;

    public GridCells(int countRows, int countColumns, T prefabView, Transform parent)
    {
        _countColumns = countColumns;
        _countRows = countRows;
        _prefabView = prefabView;
        _parent = parent;
        IsFirstClick = true;
        CanvasScaler canvasScaler = parent.GetComponent<CanvasScaler>();
        _resolutionCanvas = canvasScaler.referenceResolution;
        var vieCell = _prefabView as ViewCell;
        var sprite = vieCell.GetComponent<Image>().sprite;
        _widthSprite = sprite.rect.width * Scale;
        _heightSprite = sprite.rect.height * Scale;
         var refPixelsPerUnit = canvasScaler.referencePixelsPerUnit;
         var scaleHeightGrid = 0.8f;
         var widthPerUnitX = _resolutionCanvas.x / (refPixelsPerUnit * Scale);
         var widthPerUnitY = _resolutionCanvas.y / (refPixelsPerUnit * Scale) * scaleHeightGrid;
        _countColumns = Mathf.RoundToInt( widthPerUnitX );
        if (_countColumns > widthPerUnitX) _countColumns--;
        _countRows = Mathf.RoundToInt(widthPerUnitY);

        var percentMine = 10;
        _countMines = _countColumns * _countRows * percentMine / 100;
        
        if ( countColumns <= 0 || countRows <= 0 )
        {
            throw new ArgumentException("value count columns or count rows is not correct!");
        }

        _cells = new Cell[_countColumns, _countRows];
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
        for( var i = 0 ; i < _countColumns ; i++ )
        for( var j = 0; j < _countRows; j++ )
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
                        _cells[i, j].InitMine(valueCell, i, j);
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
        

        int indexCell = 0;
        var delta = 0;

        var camera = Camera.main;

        if (camera is null)
        {
            throw new NullReferenceException("Camera is null");
        }

        var _tabLeftForSprite = (_resolutionCanvas.x - (float)_countColumns * _widthSprite) / 2f;
        var _tabTopForSprite = _resolutionCanvas.y * 0.01f;

        var positionStart = camera.ScreenToWorldPoint(new Vector3(_tabLeftForSprite + _widthSprite/2f, 
                                                                              _tabTopForSprite + _heightSprite/2f) );

        
        for( var i = 0 ; i < _countColumns ; i++ )
        for (var j = 0; j < _countRows; j++)
        {
              ViewCells[indexCell] = Object.Instantiate(_prefabView, _parent ) as ViewCell;

              var currentPosition = new Vector3( positionStart.x, positionStart.y, 0f );
              var currentPositionScreen = camera.WorldToScreenPoint(currentPosition);
              currentPositionScreen.x += _widthSprite * (float)i ;
              currentPositionScreen.y += _heightSprite * (float)j;
              var deltaPosition = camera.ScreenToWorldPoint(currentPositionScreen);
              ViewCells[indexCell].transform.position = deltaPosition;
              ViewCells[indexCell].transform.localScale = new Vector3(Scale, Scale, 0);        
             _cells[i, j] = new Cell(ViewCells[indexCell], _parent);
             indexCell++;
        }
        
    }
    
    private void InitGrid()
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

    public Cell[,] GetCells() => _cells;


}
