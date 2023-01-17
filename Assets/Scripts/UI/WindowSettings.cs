
using UnityEngine;

public class WindowSettings : MonoBehaviour
{

    [SerializeField] private GameState _gameState; 
    
    private void Awake()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        if (_gameState.Game is GameSettings)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
    
}
