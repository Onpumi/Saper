using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public abstract class UIInputCheck : SerializedMonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //[SerializeField] private GameState _gameState;
    [SerializeField] private GameField _gameField;
    [SerializeField] private Sprite _spriteCheckOn;
    [SerializeField] private Sprite _spriteCheckOff;
    private Image _image;
    protected bool IsCheckOn { get; set; }
    //protected GameState GameState => _gameState;
    protected GameField GameField => _gameField;

    private void Awake()
    { 
        _image = GetComponent<Image>();
    }
    
    public void OnPointerDown(PointerEventData eventData ) { }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        IsCheckOn = !IsCheckOn;
        Display();
    }
    protected void Display()
    {
        _image.sprite = (IsCheckOn) ? (_spriteCheckOn) : (_spriteCheckOff);
    }
}