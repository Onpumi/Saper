

using UnityEngine;

public class Cell : ICell
{
    private readonly ViewCell _viewCell;
    public int[] Indexes { get; private set; } 
    public int Value { get; private set; }
    public bool IsOpen { get; private set; }
    public bool IsFlagged { get; private set;  }
    public bool IsInitMine { get; private set; }
    public ViewCell ViewCell => _viewCell;
    public CellData CellData { get; private set; }

    public Cell( ViewCell viewCell, int indexI, int indexJ )
    {
        Value = 0;
        _viewCell = viewCell;
        IsOpen = false;
       Indexes = new int[2];
       IsInitMine = false;
       IsFlagged = false;
       Indexes[0] = indexI;
       Indexes[1] = indexJ;
       CellData = viewCell.CellData;
    }

    public Transform GetViewTransform()
    {
        return _viewCell.transform;
    }
    
    public void Display( Vector3 position, float scale)
    {
        _viewCell.Display(this, position, scale);
    }


    public void CreateMine(int value, int indexI, int indexJ)
    {
        Value = value;
        Indexes[0] = indexI;
        Indexes[1] = indexJ;
        if (Value == -1)
        {
            IsInitMine = true;
//            _viewCell.InstantiateMine();
        }
        else IsInitMine = false;
    }
    
 

    public bool TryOpen()
    {
        if (IsOpen == true || IsFlagged ) return true;
     
        IsOpen = true;
        var viewBrick = _viewCell.transform.GetComponentInChildren<ViewBrick>();
        viewBrick.transform.gameObject.SetActive(false);
        var parentCanvas = _viewCell.transform.parent;
        ICell[,] cells = parentCanvas.GetComponent<GridCellsView>().Grid.Cells;
        
        if( Value == 0 )
        {
            var index1 = Indexes[0];
            var index2 = Indexes[1];
            FindNeighbourEmptyCellsAndOpen(cells, index1, index2);
        }
   
        return true;
    }

    public void Open()
    {
        var viewFlag = _viewCell.transform.GetComponentInChildren<ViewFlag>();
        if( viewFlag != null )
            viewFlag.transform.gameObject.SetActive(false);

        if (IsOpen == true) return;
        IsOpen = true;
        var viewBrick = _viewCell.transform.GetComponentInChildren<ViewBrick>();
        viewBrick.transform.gameObject.SetActive(false);
    }

    public void SetFlag()
    {
        if (IsOpen == true) return;
        IsFlagged = _viewCell.InitFlag();
        AndroidAPI.Vibration(50);
    }

    
    private void FindNeighbourEmptyCellsAndOpen( ICell [,] cells, int index1, int index2 )
    {
                for( int n = -1; n < 2 ; n++ )
                for( int m = -1; m < 2; m++ )
                {
                    if ( index1 + n >= 0 && index2 + m >= 0 &&
                         index1 + n <= cells.GetLength(0)-1 &&
                         index2 + m <= cells.GetLength(1)-1 &&
                         cells[index1 + n, index2 + m].Value != -1 )
                    {
                        cells[index1 + n, index2 + m].TryOpen();
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
                 cells[index1 + n, index2 + m].Value != -1 )
            {
               if( cells[index1 + n, index2 + m].Value == 0 )
                cells[index1 + n, index2 + m].TryOpen();
            }
        }
    }

    public void SetValue( int value )
    {
        Value = value;
    }
    
    public void IncrementValue()
    {
        Value++;
        _viewCell.SetTextNumbers( Value  );
    }

    public void DisableCell()
    {
        _viewCell.transform.gameObject.SetActive(false);
    }
    
    
}