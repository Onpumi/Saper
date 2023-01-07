using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _delayClickTime;
    private float _startClickTime;
    private bool _isClick = false;
    private RaycastResult _raycastResult;
    
    public void OnPointerDown(PointerEventData eventData)
    {
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
        if ((Time.time - _startClickTime) <= _delayClickTime)
        {
            var gameObject = _raycastResult.gameObject;
            var viewCell = gameObject.transform.parent.GetComponent<ViewCell>();
            if (viewCell == null) return;
            viewCell.Cell.Open();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) == true && _isClick == true && (Time.time - _startClickTime) > _delayClickTime )
        {

                var gameObj = _raycastResult.gameObject;
                if( gameObj == null ) return;
                var viewCell = gameObj.transform.parent.GetComponent<ViewCell>();
                if (viewCell == null) return;
                viewCell.Cell.SetFlag();
                _isClick = false;
        }
    }
}
