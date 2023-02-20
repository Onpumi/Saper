using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public abstract class UIInputCheck : SerializedMonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameField _gameField;
    [SerializeField] private Sprite _spriteCheckOn;
    [SerializeField] private Sprite _spriteCheckOff;
    [SerializeField] private Image _image;
    protected bool IsCheckOn { get; set; }
    protected GameField GameField => _gameField;

    private void Awake()
    {
        if (_image == null) _image = GetComponent<Image>();
    }
    
    public void OnPointerDown(PointerEventData eventData ) { }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        IsCheckOn = !IsCheckOn;
        Display();
    }
    protected void Display()
    {
        if( _image != null )
         _image.sprite = (IsCheckOn) ? (_spriteCheckOn) : (_spriteCheckOff);
    }
}