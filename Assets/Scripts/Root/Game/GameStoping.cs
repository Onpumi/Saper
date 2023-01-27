
    public class GameStoping : IGame
    {
        private bool _isRun = false;
        public bool IsRun => _isRun;
        public GameField GameField { get; private set;  }

        public GameStoping( Timer _timer )
        {
            _timer.StopTimer();
        }
    }
