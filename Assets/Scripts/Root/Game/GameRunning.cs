

public class GameRunning : IGame
{ 
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
