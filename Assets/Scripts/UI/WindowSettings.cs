
using UnityEngine;

public class WindowSettings : UIBase
{

    [SerializeField] private GameState _gameState;

    private void Awake()
    {
        SetActiveChild(false);
    }

    public override void OpenMenuSettings()
    {
        SetActiveChild(true);
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

    private void SetActiveChild( bool value )
    {
            gameObject.SetActive(value);
            foreach (Transform child in transform)
            {
                 child.gameObject.SetActive(value);
            }
    }
    
}
