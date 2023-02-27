using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _delayClickTime;
    private float _startClickTime;
    private bool _isClick = false;
    public event Action<InputHandler> OnClickCell;

    public void OnPointerDown(PointerEventData eventData)
    {
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
      if (Input.GetMouseButton(0) == true && _isClick == true && (IsTimeShort() == false) )
      {
         OnClickCell?.Invoke(this);
         _isClick = false;
      }
      
      
      
    }
    
}
