using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class MainField : MonoBehaviour
{
    [SerializeField] private ViewCell _prefabView;
    [SerializeField] private Transform _canvasParent;
    private GridCells<ViewCell> _grid;
    private Cell[,] _cells;
    public GridCells<ViewCell> Grid => _grid;
    
    private void Awake()
    {
       InitScreen();
       
    }

    private void Start()
    {
        _grid = new GridCells<ViewCell>( 8,13, _prefabView, transform );
        _cells = _grid.GetCells();
        
    }

    private void InitScreen()
    {
    
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;

        CanvasScaler canvasScaler = _canvasParent.GetComponent<CanvasScaler>();
        canvasScaler.referenceResolution = new Vector2(Screen.width,Screen.height);

        
    }
}
