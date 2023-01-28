
using UnityEngine;

public class GameRunning : IGame
{
    private bool _isRun = true;
    public bool IsRun => _isRun;
    public GameField GameField { get; private set;  }

    public GameRunning(Timer timer)
    {
        //Debug.Log("Пытаемся запустить таймер" + timer.FreezeTime);
        if (timer.FreezeTime == true)
        {
            timer.ToFreezeTime(false);
            return;
        }
        timer.StartTimer( this );
    }
}
