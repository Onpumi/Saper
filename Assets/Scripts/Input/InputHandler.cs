using UnityEngine;
using UnityEngine.EventSystems;


public class InputHandler : MonoBehaviour, IPointerDownHandler
{
    


    public void OnPointerDown(PointerEventData eventData)
    {
        var gameObject = eventData.pointerCurrentRaycast.gameObject;
        var viewCell = gameObject.transform.parent.GetComponent<ViewCell>();
        if( viewCell == null ) return;
        viewCell.Cell.Open();
    }

 
    
}
