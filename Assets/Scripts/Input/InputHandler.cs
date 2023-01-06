using UnityEngine;
using UnityEngine.EventSystems;


public class InputHandler : MonoBehaviour, IPointerDownHandler
{
    


    public void OnPointerDown(PointerEventData eventData)
    {
        var gameObject = eventData.pointerCurrentRaycast.gameObject; 
        gameObject.SetActive(false);
        var viewCell = gameObject.transform.parent.GetComponent<ViewCell>();
        Debug.Log(viewCell.Cell.Value);
        var parentCanvas = gameObject.transform.parent.parent.name;
        
        
    }

 
    
}
