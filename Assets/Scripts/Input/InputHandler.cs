using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _delayClickTime;
    
    private float _startClickTime;
    private bool _isClick = false;
    private RaycastResult _raycastResult;
    private bool _isFirstClick = true;
    private GridCells _gridCells;
    private bool _isFroze = false;
    private Transform _rootTransform;
    private GameField _gridField;


    private void Awake()
    {
        _rootTransform = transform.root.GetChild(0);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        _gridField = _rootTransform.GetComponent<GameField>();
        _raycastResult = eventData.pointerCurrentRaycast;
        _startClickTime = Time.time;
        _isClick = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ReadInputClick(eventData);
        _isClick = false;
    }

   private void ReadInputClick( PointerEventData eventData )
   {
       if (_gridField.GameState.Game.IsRun == false) return;
        if ((Time.time - _startClickTime) <= _delayClickTime )
        {
            var resultGameObject = _raycastResult.gameObject;
            if( resultGameObject.transform.parent.TryGetComponent(out CellView viewCell) == false ) return;
            if (viewCell.transform.parent.TryGetComponent(out GameField gridView) == false) return;
       
            _gridCells = gridView.Grid; 
            
            if (_gridCells.IsFirstClick)  viewCell.InitAction(_gridCells, new FirstDigDownAction(gridView));
            if (viewCell.InitAction(_gridCells, new DigDownAction(gridView)) == false)
            {
                //Debug.Log("boomm");
                _gridField.GameState.StopGame();
                _gridField.UI.UIButtonPlay.SetTransparent(1f);
                
                //_gridField.Grid.Cells[0,0].Mi
                foreach (var cell in _gridField.Grid.Cells )
                { 
                     
                }

            }
        }
    }

    private void Update()
    {
        if( Input.GetMouseButton(0) == true && _isClick == true && (Time.time - _startClickTime) > _delayClickTime  && _gridField.GameState.Game.IsRun == true)
        {
                var objectCell = _raycastResult.gameObject;
                if( objectCell.transform.parent.TryGetComponent( out CellView viewCell ) == false ) return;
                if (viewCell.transform.parent.TryGetComponent(out GameField gridView) == false) return;

                
                _gridCells = gridView.Grid;
                
              viewCell.InitAction(_gridCells, new FlagDownAction());
             _isClick = false;
        }

        if (Input.GetAxis("Cancel") > 0)
        {
            Application.Quit();
        }
    }
}
