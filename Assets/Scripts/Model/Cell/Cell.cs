using System;
using UnityEngine;
using UnityEngine.UI;

public class Cell : ICell
{
    private readonly CellView _cellView;
    public int Value { get; private set; }
    public bool IsOpen { get; private set; }
    public bool IsFlagged { get; private set;  }
    public bool IsInitMine { get; private set; }
    public CellData CellData { get; private set; }
    public bool MineSetAllow { get; private set; }
    public CellView CellView => _cellView;
    public Transform TransformView => _cellView.transform;
    public IMineView MineView { get; private set;  }

    public Cell( CellView cellView, int indexI, int indexJ )
    {
        Value = 0;
        _cellView = cellView;
        IsOpen = false;
       IsInitMine = false;
       IsFlagged = false;
       CellData = cellView.CellData;
       MineSetAllow = true;
       
    }

    /*
    public Transform GetViewTransform()
    {
        return _cellView.transform;
    }
    */
    
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
            FactoryMineView _factoryMineView = new FactoryMineView(_cellView.MineView, _cellView.transform);
            MineView = _factoryMineView.Create();
        }
        else IsInitMine = false;
    }

    public void Open()
    {
        IsOpen = true;
    }
 
    public bool SetFlag()
    {
        if (IsOpen == true) return true;
        IsFlagged = _cellView.InitFlag();
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
        return _cellView.transform.GetComponent<InputHandler>();
         
    }
    
}
