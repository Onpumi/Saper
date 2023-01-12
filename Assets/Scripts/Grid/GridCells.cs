
using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class GridCells<T>  where T : MonoBehaviour
{
    private readonly GridCellsView _gridCellsView;
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
    private ViewCell[] _viewCells;  
    public ICell[,] Cells => _cells;

    public GridCells( GridCellsView gridCellsView, T prefabView, Transform parent)
    {
        _gridCellsView = gridCellsView;
        _prefabView = prefabView;
        _parent = parent;
        IsFirstClick = true;
        CanvasScaler canvasScaler = parent.GetComponent<CanvasScaler>();
        _resolutionCanvas = canvasScaler.referenceResolution;
        var vieCell = _prefabView;
        var sprite = vieCell.GetComponent<Image>().sprite;
        _widthSprite = sprite.rect.width * Scale;
        _heightSprite = sprite.rect.height * Scale;
        var scaleHeightGrid = 0.8f;
        
        var widthPerUnit = gridCellsView.GetSizePerUnit(Scale, Scale / scaleHeightGrid);
        
        _countColumns = Mathf.RoundToInt( widthPerUnit.x );
        if (_countColumns > widthPerUnit.x) _countColumns--;
        _countRows = Mathf.RoundToInt(widthPerUnit.y);

        var percentMine = 10;
        _countMines = _countColumns * _countRows * percentMine / 100;
        
        _cells = new Cell[_countColumns, _countRows];
        _viewCells = new ViewCell[_countRows * _countColumns];
        
        //Debug.Log(_viewCells[0]);
        _firstIndexes = new int[2] { -1, -1 };
        CreateBlocks();
        InitBricks();
    }

    public void Init( ViewCell viewCell)
    {
        FindFirstIndexesOnClick( _cells[viewCell.CellData.Index1,viewCell.CellData.Index2] );
       // InitMines();
        //InitGrid();
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
          //  _viewCells[indexCell].InitIndexes(i,j);
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
                  //      _cells[i, j].InitMine(valueCell, i, j);
                        _cells[i, j].CreateMine(valueCell, i, j);
                    }
            indexCell++;
        }
    }

    //public void FindFirstIndexesOnClick( ViewCell viewCell )
    public void FindFirstIndexesOnClick( ICell cell )
    {
        //_firstIndexes[0] = viewCell.CellData.Index1;
        //_firstIndexes[1] = viewCell.CellData.Index2;
        //viewCell.Init( this, new DownActionSelection() );
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
        
/*
        int indexCell = 0;
        var delta = 0;

        var camera = Camera.main ?? throw new NullReferenceException("Camera is null");;


        var _tabLeftForSprite = (_resolutionCanvas.x - (float)_countColumns * _widthSprite) / 2f;
        var _tabTopForSprite = _resolutionCanvas.y * 0.01f;

        var positionStart = camera.ScreenToWorldPoint(new Vector3(_tabLeftForSprite + _widthSprite/2f, 
                                                                              _tabTopForSprite + _heightSprite/2f) );

        
        for( var i = 0 ; i < _countColumns ; i++ )
        for (var j = 0; j < _countRows; j++)
        {
              _viewCells[indexCell] = Object.Instantiate(_prefabView, _parent ) as ViewCell;

              var currentPosition = new Vector3( positionStart.x, positionStart.y, 0f );
              var currentPositionScreen = camera.WorldToScreenPoint(currentPosition);
              currentPositionScreen.x += _widthSprite * (float)i ;
              currentPositionScreen.y += _heightSprite * (float)j;
              var deltaPosition = camera.ScreenToWorldPoint(currentPositionScreen);
              _viewCells[indexCell].transform.position = deltaPosition;
              _viewCells[indexCell].transform.localScale = new Vector3(Scale, Scale, 0);        
             _cells[i, j] = new Cell(_viewCells[indexCell], i, j);
             indexCell++;
        }
  */
            _gridCellsView.DisplayCells( _cells, _countColumns,_countRows,Scale);        

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

    public ICell[,] GetCells() => _cells;


}
