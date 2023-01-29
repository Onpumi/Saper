using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonSettings : UIBase, IPointerDownHandler
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private WindowSettings _windowSettings;


    public void OnPointerDown(PointerEventData eventData)
    {
        _gameState.OpenSettings();
    }
   
}
