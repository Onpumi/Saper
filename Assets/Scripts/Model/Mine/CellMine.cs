
using UnityEngine;
/*
public class CellMine : ICell
{
    
    private MineView _mineView;
    public int Value { get; private set; }
    public CellData Data { get; }
    public bool IsOpen { get; private set;  }
    public bool IsFlagged { get; private set; }
    public CellData CellData { get; private set; }
    public ICellView CellView { get; private set; }
    public Transform TransformView => null;

    public void CreateMine(int value, int indexI, int indexJ)
    {
    }

    public CellMine( MineView mineView, CellData data)
    {
        _mineView = mineView;
        Data = data;
        Value = 0;
    }

    public Transform GetViewTransform()
    {
        return _mineView.transform;
    }

    public bool TryOpen()
    {
        if (IsOpen == true || IsFlagged ) return true;
        //_mineView.InstantiateBoom();
        return true;
    }


    public void SetFlag()
    {
        if (IsOpen == true) return;

        if (_mineView.transform.parent.TryGetComponent(out CellView viewCell))
        {
            IsFlagged = viewCell.InitFlag();
            AndroidAPI.Vibration(50);
            
        }
        

    }

    public void Display(Vector3 position, float scale)
    {
            _mineView.transform.gameObject.SetActive(IsOpen);
    }

    public void Open()
    {
        _mineView.transform.gameObject.SetActive(true);
    }

    public void IncrementValue()
    {
    }

    public void SetValue(int value)
    {
        Value = value;
    }

    //public void CreateMine(int valueCell, int i, int j)
    //{
    //}

}

*/