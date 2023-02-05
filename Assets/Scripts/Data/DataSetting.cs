


using UnityEngine;

public class DataSetting
{
    private GameField _gameField;
    public AudioData AudioData { get; private set; }
    public ScreenData ScreenData { get; private set; }
    public GameData GameData { get; private set; }

    public DataSetting( GameField gameField )
    {
        _gameField = gameField;
        CalculateScaleBrick();
        AudioData = new AudioData("AudioKey");
        AudioData.Load();
        ScreenData = new ScreenData("ScreenKey");
        ScreenData.Load();
        GameData = new GameData("GameKey", gameField );
        GameData.Load();
        InitScreen();
    }

    private void InitScreen()
    {
        Screen.fullScreenMode = (ScreenData.GetValue(TypesScreen.ScreenFullOn)) ? (FullScreenMode.MaximizedWindow) : (FullScreenMode.Windowed);
        Screen.sleepTimeout = (ScreenData.GetValue(TypesScreen.ScreenSleepTimeOutOn)) ? (SleepTimeout.SystemSetting) : (SleepTimeout.NeverSleep);
    }
    
    public void SetScreen( TypesScreen typesScreen, bool value )
    {
        if (typesScreen == TypesScreen.ScreenFullOn)
        {
            Screen.fullScreenMode = (value) ? (FullScreenMode.MaximizedWindow) : (FullScreenMode.Windowed);
        }
        else if (typesScreen == TypesScreen.ScreenSleepTimeOutOn)
        {
            Screen.sleepTimeout = (value) ? (SleepTimeout.SystemSetting) : (SleepTimeout.NeverSleep);
        }
    }

    public void CalculateScaleBrick()
    {
        var screenAdjusment = _gameField.ScreenAdjusment;
        var spriteData = _gameField.SpriteData;
        var needCountBricks = _gameField.NeedCountBricks;
        var ScaleBrick = 1f;
        var screenArea = screenAdjusment.ResolutionCanvas.x * screenAdjusment.ResolutionCanvas.y;
        var spriteArea = spriteData.Width * spriteData.Height;
        var deltaScale = Mathf.Sqrt(screenArea / (needCountBricks * spriteArea));
        ScaleBrick *= deltaScale;
    }
    
    
}