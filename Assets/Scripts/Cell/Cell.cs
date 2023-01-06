

using UnityEngine;

public class Cell : ICell
{
    private readonly ViewCell _viewCell;
    private readonly ViewMine _viewMine;
    private Transform _parentCanvas;
    public int Value { get; private set; }
    public bool IsOpen { get; private set; }
    
    public Cell( ViewCell viewCell, Transform parent )
    {
        Value = 0;
        _viewCell = viewCell;
        IsOpen = false;
        _parentCanvas = parent;
    }

    public void Init( int value )
    {
        Value = value;
        if (Value == -1)
        {
           _viewCell.InstantiateMine( );
        }
        _viewCell.InstatiateBricks();
    }

    public void Open()
    {
        IsOpen = true;
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
    
     
    
    
    
}
