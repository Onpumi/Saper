
using UnityEngine;

public class WindowSettings : UIBase
{

    [SerializeField] private GameState _gameState; 
    
    public override void OpenMenuSettings()
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
    }

    private void Update()
    {
        if (Input.GetAxis("Cancel") > 0)
        {
            if( _gameState.Game is GameSettings )
             _gameState.StartGame();
            gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Space)  )
        {
            if( _gameState.Game is GameSettings )
             _gameState.StartGame();
            gameObject.SetActive(false);
        }
    }
    
}
