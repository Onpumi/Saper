using System;
using UnityEngine;




public class FieldCells 
{
    private readonly GameField _gameField;
    private readonly int _countColumns;
    private readonly int _countRows;
    private readonly ICell[,] _cells;
    private readonly int[] _firstIndexes;
    private SpawnerField _spawnerField;
    public int CountOpen { get; private set; }
    private int _countFlagTrue;

    private readonly ContainerMines _containerMines;
    private int _percentMine = 15;
    public int CountCells { get; private set; }
    public bool IsFirstClick { get; private set; }
    public ICell[,] Cells => _cells;
    public GameField GameField => _gameField;


    public FieldCells( GameField gameField, float scaleBrick, float scaleHeightGrid )
    {
        //scaleBrick = 1.7f;
        _gameField = gameField;
        IsFirstClick = true;
        var widthPerUnit = gameField.GetSizePerUnit(scaleBrick, scaleBrick / scaleHeightGrid);
        _countColumns = Mathf.RoundToInt( widthPerUnit.x );
        if (_countColumns > widthPerUnit.x) _countColumns--;
        _countRows = Mathf.RoundToInt(widthPerUnit.y);
        
       // _countMines = _countColumns * _countRows * percentMine / 100;
        _cells = new ICell[_countColumns, _countRows];
        CountCells = _cells.Length;
        _firstIndexes = new int[2] { -1, -1 };
        _containerMines = new ContainerMines( this._gameField, _cells, _firstIndexes );
       _spawnerField = new SpawnerField(this, _containerMines, _cells, scaleBrick, _countColumns, _countRows);
        _spawnerField.CreateBlocks();
      //  CountFlags = _countMines;
    }

    

    public void ConfirmFirstClick()
    {
        IsFirstClick = false;
        _gameField.NotActiveListBeforeStartUI.ForEach( ui => ui.EnableForDisplay());
        
    }

    public void Reset() => IsFirstClick = true;

    public void FindFirstIndexesOnClick( ICell cell )
    {
        _firstIndexes[0] = cell.CellData.Index1;
        _firstIndexes[1] = cell.CellData.Index2;
        IsFirstClick = false;
    }

    public void GenerateMines()
    {
        var countCells = _countColumns * _countRows;
        _containerMines.GenerateMines( _percentMine, countCells );
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

    public void IncrementFlagCount()
    {
        _countFlagTrue++;
    }

    public bool isWin() => (_countFlagTrue + CountOpen) >= CountCells;
    
    public bool TryOpen( ICell cell )
    {
        if (cell.IsOpen == true || cell.IsFlagged ) return true;

        cell.Open();
        _gameField.Sounds.PlayAudio(TypesAudio.SoundClick);

        CountOpen++;
        
        MineView mineView = null;

        foreach (Transform child in cell.CellView.GetTransform())
        {
            if( child.TryGetComponent(out MineView view2))
                mineView = child.GetComponent<MineView>() 
                           ?? throw new ArgumentException("mineView need to be is not null"); 
        }
        
        
        
        if( cell.Value == 0 )
        {
            var index1 = cell.CellData.Index1;
            var index2 = cell.CellData.Index2;
            FindNeighbourEmptyCellsAndOpen(_cells, index1, index2);
            _gameField.Sounds.PlayAudio(TypesAudio.SoundEmpty);
        }
        else if (cell.Value == -1)
        {
            mineView.ActivateMine(cell.CellView.GetTransform());
            _gameField.Sounds.PlayAudio(TypesAudio.SoundExplode);
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
                FindNeighbourWithoutMineCellsAndOpen(index1 + n, index2 + m);
            }
        }
    }

    private void FindNeighbourWithoutMineCellsAndOpen( int index1, int index2 )
    {
        for( int n = -1; n < 2 ; n++ )
        for( int m = -1; m < 2; m++ )
        {
            if ( index1 + n >= 0 && index2 + m >= 0 &&
                 index1 + n <= _cells.GetLength(0)-1 &&
                 index2 + m <= _cells.GetLength(1)-1 &&
                 _cells[index1 + n, index2 + m].Value > 0)
            {
                if (_cells[index1 + n, index2 + m].Value > 0)
                    TryOpen(_cells[index1 + n, index2 + m]);
            }
        }
    }


    public void OpenAll()
    {
        foreach (var cell in _cells)
        {
            cell.Open();
            if(cell.IsInitMine) cell.CellView.MineView.transform.gameObject.SetActive(true);
            
            cell.CellView.FlagView.transform.SetParent(cell.CellView.GetTransform());
            if (cell.IsInitMine == false && cell.CellView.FlagView.Value)
            {
                cell.CellView.FlagView.SetFlagError();
            }
            else
            {
                cell.CellView.FlagView.transform.gameObject.SetActive(false);    
            }

            cell.CellView.GetInput().enabled = false;
        }
    }
    
    
    public ICell[,] GetCells() => _cells;


}
