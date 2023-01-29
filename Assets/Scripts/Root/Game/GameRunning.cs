

public class GameRunning : IGame
{
    public GameField GameField { get; private set;  }

    public GameRunning(Timer timer)
    {
        if (timer.FreezeTime == true)
        {
            timer.ToFreezeTime(false);
            return;
        }
        timer.StartTimer( this );
    }
}
