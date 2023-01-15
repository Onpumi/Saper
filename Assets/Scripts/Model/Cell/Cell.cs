using UnityEngine;
using UnityEngine.UI;

public class Cell : ICell
{
    private readonly CellView _cellView;
    public int[] Indexes { get; private set; } 
    public int Value { get; private set; }
    public bool IsOpen { get; private set; }
    public bool IsFlagged { get; private set;  }
    public bool IsInitMine { get; private set; }
    public CellData CellData { get; private set; }
    public bool MineSetAllow { get; private set; }
    public ICellView CellView => _cellView;
    public Transform TransformView => _cellView.transform;
    public MineView MineView { get; private set;  }

    public Cell( CellView cellView, int indexI, int indexJ )
    {
        Value = 0;
        _cellView = cellView;
        IsOpen = false;
       Indexes = new int[2];
       IsInitMine = false;
       IsFlagged = false;
       Indexes[0] = indexI;
       Indexes[1] = indexJ;
       CellData = cellView.CellData;
       MineSetAllow = true;
       
    }

    public Transform GetViewTransform()
    {
        return _cellView.transform;
    }
    
    public void Display( Vector3 position, float scale)
    {
        _cellView.Display(this, position, scale);
    }


    public void CreateMine(int value, int indexI, int indexJ)
    {
        Value = value;
        Indexes[0] = indexI;
        Indexes[1] = indexJ;
        if (Value == -1)
        {
            IsInitMine = true;
            FactoryMineView _factoryMineView = new FactoryMineView(_cellView.MineView, _cellView.transform);
            MineView = _factoryMineView.Create();
            MineView.transform.localScale = 0.5f * Vector3.one;
            MineView.transform.gameObject.SetActive(false);
        }
        else IsInitMine = false;
    }
    
 

    public bool TryOpen()
    {
        if (IsOpen == true || IsFlagged ) return true;
     
        IsOpen = true;
        var viewBrick = _cellView.transform.GetComponentInChildren<BrickView>();
        viewBrick.transform.gameObject.SetActive(false);
        var parentCanvas = _cellView.transform.parent;
        ICell[,] cells = parentCanvas.GetComponent<GameField>().Grid.Cells;
        
        if( Value == 0 )
        {
            var index1 = Indexes[0];
            var index2 = Indexes[1];
            FindNeighbourEmptyCellsAndOpen(cells, index1, index2);
        }
        else if (Value == -1)
        {
            MineView.gameObject.SetActive(true);
            _cellView.GetComponent<Image>().color = Color.red;
            return false;
        }
            
   
        return true;
    }

    public void Open()
    {
        var viewFlag = _cellView.transform.GetComponentInChildren<FlagView>();
        if( viewFlag != null )
            viewFlag.transform.gameObject.SetActive(false);

        if (IsOpen == true) return;
        IsOpen = true;
        var viewBrick = _cellView.transform.GetComponentInChildren<BrickView>();
        viewBrick.transform.gameObject.SetActive(false);
    }

    public void SetFlag()
    {
        if (IsOpen == true) return;
        IsFlagged = _cellView.InitFlag();
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
    
    public void IncrementValue()
    {
        Value++;
        _cellView.SetTextNumbers( Value  );
    }

    public void DisableCell()
    {
        _cellView.transform.gameObject.SetActive(false);
    }



    public void TrySetMineAfterFirstClick(int index1, int index2)
    {
        
        
    }
    
    
    
}
