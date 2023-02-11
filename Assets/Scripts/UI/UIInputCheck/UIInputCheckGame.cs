using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputCheckGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private TypesOption TypeOption;


    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _gameState.OpenMenuSizeCells();
    }
    
}
