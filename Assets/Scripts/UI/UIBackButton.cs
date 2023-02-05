using UnityEngine;
using UnityEngine.EventSystems;

public class UIBackButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private WindowSettings _windowSettings;
    

    public void OnPointerDown( PointerEventData eventData )
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if( _gameState.Game is GameSettings )
            _gameState.StartGame();
        _windowSettings.gameObject.SetActive(false);
        
    }
    
}
