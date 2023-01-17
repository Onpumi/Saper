using UnityEngine;

public class GameSettings : IGame
{
    private bool _isRun = false;
    public bool IsRun => _isRun;
    public GameField GameField { get; private set;  }

    public GameSettings( GameField gameField )
    {
        GameField = gameField;
        Debug.Log(gameField.transform.name);
        gameField.transform.gameObject.SetActive(false);
    }
}