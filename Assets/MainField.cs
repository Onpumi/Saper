using UnityEngine;

public class MainField : MonoBehaviour
{
    [SerializeField] private ViewCell _prefabView;
    [SerializeField] private ViewMine _prefabViewMine;
    private GridCells<ViewCell> _grid;
    private Cell[,] _cells;
    public GridCells<ViewCell> Grid => _grid;
    

    private void Awake()
    {
       _grid = new GridCells<ViewCell>( 8,13, _prefabView, transform );
       _cells = _grid.GetCells();
    }

}
