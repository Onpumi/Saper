


using UnityEngine;

public class DataSetting
{
    public AudioData AudioData { get; private set; }
    public ScreenData ScreenData { get; private set; }

    public DataSetting()
    {
        AudioData = new AudioData("AudioKey");
        AudioData.Load();
        ScreenData = new ScreenData("ScreenKey");
        ScreenData.Load();
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
    
}