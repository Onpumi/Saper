using UnityEngine;
public class CellMine : ICell
{
    
    private ViewMine _viewMine;
    public int Value { get; private set; }
    public CellData Data { get; }
    public bool IsOpen { get; private set;  }
    public bool IsFlagged { get; private set; }
    public CellData CellData { get; private set; }


    public void CreateMine(int value, int indexI, int indexJ)
    {
    }

    public CellMine( ViewMine viewMine, CellData data)
    {
        _viewMine = viewMine;
        Data = data;
        Value = 0;
    }

    public Transform GetViewTransform()
    {
        return _viewMine.transform;
    }

    public bool TryOpen()
    {
        if (IsOpen == true || IsFlagged ) return true;
        //Debug.Log("Мина!");
        _viewMine.InstantiateBoom();
        return true;
    }


    public void SetFlag()
    {
        
    }

    public void Display(Vector3 position, float scale)
    {
            _viewMine.transform.gameObject.SetActive(IsOpen);
    }

    public void Open()
    {
        _viewMine.transform.gameObject.SetActive(true);
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