using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonSettings : MonoBehaviour, IPointerDownHandler, IUI
{
    [SerializeField]  private GameState _gameState;
    [SerializeField] private WindowSettings _windowSettings;


    public void OnPointerDown(PointerEventData eventData)
    {
        _windowSettings.enabled = true;
        _windowSettings.gameObject.SetActive(true);
        _gameState.OpenSettings(_gameState.GameField);
    }
    
    public void Lose() { }

    public void EnableForDisplay()
    {
        gameObject.SetActive(true);
    }

    public void OpenMenuSettings()
    {
        gameObject.SetActive(false);
    }
}
