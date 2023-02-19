
    public class GameStoping : IGame
    {
        public GameStoping( Timer _timer )
        {
            _timer.StopTimer();
        }
    }
