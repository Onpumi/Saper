using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputCheckGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private TypesOption TypeOption;
    [SerializeField] private WindowsSizeCells _windowsSizeCells;


    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _windowsSizeCells.Open(true);
        _gameState.OpenMenuSizeCells();
    }
    
}
