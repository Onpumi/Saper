
using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class GridCells<T>  where T : Object
{
    private int _countColumns;
    private int _countRows;
    private Cell[,] _cells;
    private Vector3 _tab;
    private int _countMines = 30;
    private const float Scale = 0.5f;
    public ViewCell[] ViewCells { get; private set;  }  
    
    public GridCells(  int countColumns, int countRows, T prefabView, Transform parent )
    {
        
        _countColumns = countColumns;
        _countRows = countRows;
        
        if ( countColumns <= 0 || countRows <= 0 )
        {
            throw new ArgumentException("value count columns or count rows is not correct!");
        }

        _cells = new Cell[_countRows, _countColumns];
        var worldPoint = Camera.main.ScreenToWorldPoint(new Vector2(0, 10));
        var startPosition = new Vector3( worldPoint.x,worldPoint.y);
        var arrayMines = new int[_countRows * _countColumns];

        ViewCells = new ViewCell[_countRows * _countColumns];

        int countMaxIteration = 10000;
        int countIteration = 0;

        startPosition = Camera.main.ScreenToWorldPoint( new Vector3(0f,0f, 0f) );
       
        for ( var i = 0; i < _countMines; i++)
        {
            if (countIteration > countMaxIteration) break;
            
            var randomIndexMine = UnityEngine.Random.Range(0,arrayMines.Length-1);
            if( arrayMines[randomIndexMine] == -1 )
            {
                i--;
                countIteration++;
                continue;
            }
            arrayMines[randomIndexMine] = -1;
        }

        var indexMine = 0;

        CanvasScaler canvasScaler = parent.gameObject.GetComponent<CanvasScaler>();
        var referencePixelsPerUnit = canvasScaler.referencePixelsPerUnit;

        var scaleBrick = new Vector3(1 / referencePixelsPerUnit, 1 / referencePixelsPerUnit) * Scale;

        int indexCell = 0;
        for( var i = 0 ; i < _countRows ; i++ )
        for( var j = 0; j < _countColumns; j++ )
        {
            ViewCells[indexCell] = Object.Instantiate(prefabView, startPosition, Quaternion.identity) as ViewCell;
            ViewCells[indexCell].transform.localScale = scaleBrick;
            ViewCells[indexCell].transform.SetParent( parent );
            var widthSprite = ViewCells[indexCell].GetComponent<Image>().sprite.rect.width;
            var heightSprite = ViewCells[indexCell].GetComponent<Image>().sprite.rect.height;
            var position = startPosition;
            var deltaX = scaleBrick.x * widthSprite;
            var deltaY = scaleBrick.y * heightSprite;
            var _tabX = deltaX / 3f;  
            var _tabY = deltaY / 3f;
            
            ViewCells[indexCell].transform.position = new Vector3( position.x + deltaX/2f + deltaX * (i + i*_tabX), position.y + deltaY * (j + j*_tabY), 0f);
            _cells[i, j] = new Cell(ViewCells[indexCell], parent);
            _cells[i,j].Init(arrayMines[indexMine++]);
            ViewCells[indexCell].CellInput(_cells[i,j]);
            indexCell++;
        }

        InitGrid();
    }

    private void InitGrid()
    {
        for( var i = 0 ; i < _countRows ; i++ )
        for( var j = 0; j < _countColumns; j++)
        {
             if( _cells[i, j].Value != -1 && i > 0 && j > 0 && i < _cells.GetLength(0)-1 && j < _cells.GetLength(1)-1)
             {
                for( int n = -1; n < 2 ; n++ )
                for( int m = -1; m < 2; m++ )
                {
                   if ( _cells[i + n, j + m].Value == -1 )
                   {
                     _cells[i,j].IncrementValue();
                   }
                }
             }
        }
    }

    public Cell[,] GetCells() => _cells;


}
