
using UnityEngine;
using UnityEngine.UI;

public class WindowSettings : MonoBehaviour, IUI
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
    
    public void Lose()
    {
        
    }

    public void OpenMenuSettings()
    {
        
    }


    private void Update()
    {
        if (Input.GetAxis("Cancel") > 0)
        {
           _gameState.StartGame(); 
        }
    }
    
}
