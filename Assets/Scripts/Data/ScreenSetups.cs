[System.Serializable]
public class ScreenSetups 
{
    public bool ScreenSleepModeOn;
    public bool ScreenFullOn;

    public ScreenSetups()
    {
        ScreenSleepModeOn = true;
        ScreenFullOn = true;
    }

    public void SetupValue( TypesScreen typeScreen, bool value )
    {
        switch (typeScreen)
        {
            case TypesScreen.ScreenFullOn : ScreenFullOn = value; break;
            case TypesScreen.ScreenSleepTimeOutOn : ScreenSleepModeOn = value; break;
        }
    }

    public bool GetValue(TypesScreen typeScreen)
    {
        switch (typeScreen)
        {
            case TypesScreen.ScreenSleepTimeOutOn : return ScreenSleepModeOn; 
            case TypesScreen.ScreenFullOn : return ScreenFullOn; 
        }
        return true;
    }
    
    
}