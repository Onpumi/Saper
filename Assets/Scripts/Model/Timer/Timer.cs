using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Timer
{
    private int _timeSecondValue = 0;
    private readonly UITimer _uiTimer;
    private const int TimeLengthSecond = 1000;
    private const int StepTime = 100;
    public bool FreezeTime { get; private set; }
    private CancellationTokenSource _cancellationTokenSource;
    private bool _isRunTimer = false;
    public int ResultTme { get; private set; }

    public Timer( UITimer uiTimer )
    {
        _uiTimer = uiTimer;
        FreezeTime = false;
    }

    public async void StartTimer( IGame game )
    {
        if (_isRunTimer) return;
        _timeSecondValue = 0;

        if (game is GameRunning)
        {
             _cancellationTokenSource = new CancellationTokenSource();
            int countTime = 0;
            while (true)
            {
                if (_cancellationTokenSource.Token.IsCancellationRequested) return;
                await Task.Delay(StepTime);
                countTime += StepTime;
                if (countTime % TimeLengthSecond == 0)
                {
                    if(FreezeTime == false)
                        _timeSecondValue++;
                    countTime = 0;
                }
                _uiTimer.Display(_timeSecondValue);
            }
            
        }
    }

    public void ToFreezeTime( bool value ) => FreezeTime = value;

    public void StopTimer()
    {
        if(_cancellationTokenSource != null)
         _cancellationTokenSource.Cancel();
        ResultTme = _timeSecondValue;
        _isRunTimer = false;
        FreezeTime = false;
    }
}
