using UnityEngine;

public class GameSettings : IGame
{
    public GameSettings(GameState gameState, Timer timer)
    {
        if ( gameState.Game is GameRunning )
        {
            timer.ToFreezeTime(true);
        }
    }
    
}