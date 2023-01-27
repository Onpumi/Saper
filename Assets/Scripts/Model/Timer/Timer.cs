using System.Threading;
using System.Threading.Tasks;

public class Timer
{
    private int _timeSecondValue = 0;
    private UITimer _uiTimer;
    private const int TimeLengthSecond = 1000;
    private const int StepTime = 100;
    private bool _freezeTime;
    private CancellationTokenSource _cancellationTokenSource;
    public int ResultTme { get; private set; }

    public Timer( UITimer uiTimer )
    {
        _uiTimer = uiTimer;
        _freezeTime = false;
    }

    public async void StartTimer( IGame game )
    {
        if( _freezeTime == true ) ToFreezeTime(false);
        else _timeSecondValue = 0;
        if (game is GameRunning)
        {
            if( _cancellationTokenSource == null )
             _cancellationTokenSource = new CancellationTokenSource();
            int countTime = 0;
            while (_freezeTime == false)
            {
                if (_cancellationTokenSource.Token.IsCancellationRequested) return;
                await Task.Delay(StepTime);
                countTime += StepTime;
                if (countTime % TimeLengthSecond == 0)
                {
                    _timeSecondValue++;
                    countTime = 0;
                }
                _uiTimer.Display(_timeSecondValue);
            }
            
        }
    }

    public void ToFreezeTime( bool value ) => _freezeTime = value;

    public void StopTimer()
    {
        _cancellationTokenSource.Cancel();
        ResultTme = _timeSecondValue;
    }
}
