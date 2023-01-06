using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private ViewCell _prefabView;
    [SerializeField] private ViewMine _prefabViewMine;
    private GridCells<ViewCell> _grid;
    private Cell[,] _cells;
    

    private void Awake()
    {
       _grid = new GridCells<ViewCell>( 15,10, _prefabView, transform );
       _cells = _grid.GetCells();
    }

    public GridCells<ViewCell> GetGridCells() => _grid;

}
