
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
            _gameState.StartGame();
           gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Space)  )
        {
            _gameState.StartGame();
            gameObject.SetActive(false);
        }
    }
    
}
