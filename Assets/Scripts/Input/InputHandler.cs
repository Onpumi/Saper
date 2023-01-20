using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _delayClickTime;

    private IDownAction _downAction;
    private float _startClickTime;
    private bool _isClick = false;
    private RaycastResult _raycastResult;
    private bool _isFirstClick = true;
    private GridCells _gridCells;
    private bool _isFroze = false;
    private Transform _rootTransform;
    private GameField _gridField;
    private GameState _gameState;
    public event Action<InputHandler> OnClickCell;

    private void Awake()
    {
        _rootTransform = transform.root ?? throw new ArgumentNullException(nameof(transform.root));
        _gameState = _rootTransform.GetComponent<GameState>();
        _gridField = _gameState.GameField;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        _raycastResult = eventData.pointerCurrentRaycast;
        _startClickTime = Time.time;
        _isClick = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       if( _isClick == true )
        OnClickCell?.Invoke(this);
       _isClick = false;
    }

    public bool IsTimeShort() => ((Time.time - _startClickTime) <= _delayClickTime);

    private void Update()
    {
        if (Input.GetMouseButton(0) == true && _isClick == true && (IsTimeShort() == false) && _gameState.Game.IsRun == true)
        {
            OnClickCell?.Invoke(this);
            _isClick = false;
        }
    }
}
