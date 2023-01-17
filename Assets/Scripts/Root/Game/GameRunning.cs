
public class GameRunning : IGame
{
    private bool _isRun = true;
    public bool IsRun => _isRun;
    public GameField GameField { get; private set;  }
}
