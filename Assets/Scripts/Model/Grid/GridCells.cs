
using UnityEngine;
using System.Collections.Generic;



public class GridCells 
{
    private readonly GridCellsView _gridCellsView;
    private readonly ViewMine _prefabViewMine;
    private readonly int _countColumns;
    private readonly int _countRows;
    private ICell[,] _cells;
    private readonly int _countMines;
    private readonly int[] _firstIndexes;
    private readonly float _scaleBrick;
    public bool IsFirstClick { get; private set; }
    public ICell[,] Cells => _cells;


    public GridCells( GridCellsView gridCellsView, ViewMine prefabViewMine, float scaleBrick, float scaleHeightGrid )
    {
        _gridCellsView = gridCellsView;
        _prefabViewMine = prefabViewMine;
        _scaleBrick = scaleBrick;
        IsFirstClick = true;
        var widthPerUnit = gridCellsView.GetSizePerUnit(_scaleBrick, _scaleBrick / scaleHeightGrid);
        _countColumns = Mathf.RoundToInt( widthPerUnit.x );
        if (_countColumns > widthPerUnit.x) _countColumns--;
        _countRows = Mathf.RoundToInt(widthPerUnit.y);
        var percentMine = 10;
        _countMines = _countColumns * _countRows * percentMine / 100;
        _cells = new ICell[_countColumns, _countRows];
        _firstIndexes = new int[2] { -1, -1 };
        CreateBlocks();
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
            var parent = _cells[indexRandom, j].GetViewTransform(); 
            var cell = _cells[indexRandom, j];
            var maxIteration = 10000;
            var iteration = 0;
  
            var factoryViewMine = new FactoryViewMine(_prefabViewMine, parent);
            FactoryMine factoryMine = new FactoryMine( factoryViewMine, cell.CellData);
            _cells[indexRandom , j] = factoryMine.Create();
            _cells[indexRandom, j].SetValue(-1);
            _cells[indexRandom, j].CreateMine(-1,indexRandom,j);
                     
            
        }
    }

    private List<int[]> FindBanNearIndexes(int firstIndex, int secondIndex)
    {
        //int[] result = { 0,0} ;
        List<int[]> banIndexes = new List<int[]>();

        foreach (var cell in Cells)
        {
            for( int k = -1 ; k < 1 ; k++ )
            if (cell.CellData.Index1 == firstIndex && cell.CellData.Index2 == secondIndex + k)
            {
                int[] result = { cell.CellData.Index1,cell.CellData.Index2};
                banIndexes.Add(  result );
            }
        }
        

        return banIndexes;
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
