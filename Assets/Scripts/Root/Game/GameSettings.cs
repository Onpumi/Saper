using UnityEngine;

public class GameSettings : IGame
{
    private bool _isRun = false;
    public bool IsRun => _isRun;
    public GameField GameField { get; private set;  }

    public GameSettings( GameField gameField )
    {
        GameField = gameField;
        gameField.transform.gameObject.SetActive(false);
    }
}