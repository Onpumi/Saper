
using UnityEngine;

public interface ICellView
{
    public void Display(ICell cell, Vector3 positionStart, float scale );
    public void InitCellData(CellData cellData);
}
