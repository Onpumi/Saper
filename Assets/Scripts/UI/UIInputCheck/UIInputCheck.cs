using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public abstract class UIInputCheck : SerializedMonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameField _gameField;
    [SerializeField] private UICheckButton _uiCheckButton;
    
    protected bool IsCheckOn { get; set; }
    protected GameField GameField => _gameField;

    public void OnPointerDown(PointerEventData eventData ) { }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        IsCheckOn = !IsCheckOn;
        Display();
    }
    protected void Display()
    {
         
        if (_uiCheckButton != null)
        {
            _uiCheckButton.SetSprite(IsCheckOn);
        }
        
    }
}