

using UnityEngine;

public class Cell : ICell
{
    private readonly ViewCell _viewCell;
    public int[] Indexes { get; private set; } 
    public int Value { get; private set; }
    public bool IsOpen { get; private set; }
    public bool IsInitMine { get; private set; }
    
    public Cell( ViewCell viewCell, Transform parent )
    {
        Value = 0;
        _viewCell = viewCell;
        IsOpen = false;
       Indexes = new int[2];
       IsInitMine = false;
    }

    public void Init( int value, int indexI, int indexJ )
    {
        Value = value;
        Indexes[0] = indexI;
        Indexes[1] = indexJ;
        if (Value == -1)
        {
           _viewCell.InstantiateMine( );
        }
        _viewCell.InstatiateBricks();
    }

    public void Open()
    {
        if (IsOpen == true) return;
        IsOpen = true;
        var viewBrick = _viewCell.transform.GetComponentInChildren<ViewBrick>();
        viewBrick.transform.gameObject.SetActive(false);
        var parentCanvas = _viewCell.transform.parent;
        var cells = parentCanvas.GetComponent<MainField>().Grid.Cells;

        if (_viewCell.Cell.Value == 0)
        {
            var index1 = _viewCell.Cell.Indexes[0];
            var index2 = _viewCell.Cell.Indexes[1];
            FindNeighbourEmptyCellsAndOpen(cells, index1, index2);
        }
        
    }

    
    private void FindNeighbourEmptyCellsAndOpen( Cell [,] cells, int index1, int index2 )
    {
                for( int n = -1; n < 2 ; n++ )
                for( int m = -1; m < 2; m++ )
                {
                    if ( index1 + n >= 0 && index2 + m >= 0 &&
                         index1 + n <= cells.GetLength(0)-1 &&
                         index2 + m <= cells.GetLength(1)-1 &&
                         cells[index1 + n, index2 + m].Value == 0 )
                    {
                        cells[index1 + n, index2 + m].Open();
                        FindNeighbourWithoutMineCellsAndOpen(cells, index1 + n, index2 + m);
                    }
                }
    }
    
    private void FindNeighbourWithoutMineCellsAndOpen( Cell [,] cells, int index1, int index2 )
    {
        for( int n = -1; n < 2 ; n++ )
        for( int m = -1; m < 2; m++ )
        {
            if ( index1 + n >= 0 && index2 + m >= 0 &&
                 index1 + n <= cells.GetLength(0)-1 &&
                 index2 + m <= cells.GetLength(1)-1 &&
                 cells[index1 + n, index2 + m].Value != -1 )
            {
                cells[index1 + n, index2 + m].Open();
            }
        }
    }
    
    
    

    public void SetColor( Color color )
    {
        _viewCell.SetColor( color );
    }

    public void IncrementValue()
    {
        Value++;
        _viewCell.SetTextNumbers( Value  );
    }


    public void FindEmptyCellsAndOpen( Cell cell)
    {
        var i = cell.Indexes[0];
        var j = cell.Indexes[1];
        
    }

    private void OpenEmptyNearCells()
    {
        
    }
     
    
    
    
}
