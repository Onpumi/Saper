using System;
using UnityEngine;
using UnityEngine.UI;

public class Cell : ICell
{
    private readonly ICellView _cellView;
    private Flag _flag;
    public int Value { get; private set; }
    public bool IsOpen { get; private set; }
    public bool IsFlagged { get; private set;  }
    public bool IsInitMine { get; private set; }
    public CellData CellData { get; private set; }
    public bool MineSetAllow { get; private set; }
    public ICellView CellView => _cellView;
    //public Transform TransformView => _cellView.transform;

    public Cell( ICellView cellView, int indexI, int indexJ )
    {
        Value = 0;
        _cellView = cellView;
        IsOpen = false;
       IsInitMine = false;
       IsFlagged = false;
       CellData = cellView.GetCellData();
       MineSetAllow = true;
       _flag = new Flag( _cellView, _cellView.FlagView );
    }

    public void Display( Vector3 position, float scale)
    {
        _cellView.Display(this, position, scale);
    }

    public void CreateMine(int value, int indexI, int indexJ)
    {
        Value = value;
        if (Value == -1)
        {
            IsInitMine = true;
            FactoryMineView factoryMineView = new FactoryMineView(_cellView.MineView, _cellView.GetTransform());
            var mineView = factoryMineView.Create();
        }
        else IsInitMine = false;
    }

    public void Open()
    {
        IsOpen = true;
    }
 
    public bool SetFlag( int countFlags )
    {
        if (IsOpen == true) return true;
        //IsFlagged = _cellView.InitFlag();

        IsFlagged = _flag.SetFlag( countFlags );
        AndroidAPI.Vibration(50);
        return IsFlagged;
    }

 
    public void IncrementValue()
    {
        Value++;
        _cellView.SetTextNumbers( Value  );
    }

    public InputHandler GetInputHandler()
    {
        return _cellView.GetInput();
    }
    
}
