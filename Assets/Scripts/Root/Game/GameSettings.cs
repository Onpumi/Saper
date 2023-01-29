using UnityEngine;

public class GameSettings : IGame
{
    public GameField GameField { get; private set;  }


    public GameSettings(GameField gameField, Timer timer)
    {
        if (gameField.GameState.Game is GameRunning)
        {
            timer.ToFreezeTime(true);
        }
    }
    
}