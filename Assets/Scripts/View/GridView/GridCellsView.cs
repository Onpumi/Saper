using UnityEngine;
using UnityEngine.UI;

public class GridCellsView : MonoBehaviour, IGridCellsView
{
    [SerializeField] private ViewCell _prefabView;
    [SerializeField] private Transform _canvasParent;
    private GridCells<ViewCell> _grid;
    private Cell[,] _cells;
    private ScreenAdjusment _screenAdjusment;
    public GridCells<ViewCell> Grid => _grid;
    
    private void Awake()
    {
        _screenAdjusment = new ScreenAdjusment( transform );
    }

    private void Start()
    {
        _grid = new GridCells<ViewCell>(this, _prefabView, transform);
        _cells = _grid.GetCells();
    }


    public void DisplayCells()
    {
        
    }


}
