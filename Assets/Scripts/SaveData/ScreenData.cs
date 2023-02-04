public class ScreenData : SavingData<ScreenSetups,TypesScreen>
{
    public ScreenData( string key )
    {
        base.Key = key;
    }
    
    public void SetupValue( TypesScreen typeScreen, bool value )
    {
        _dataSetups.SetupValue(typeScreen, value);
        Save();
    }

    public bool GetValue(TypesScreen typeScreen)
    {
        return _dataSetups.GetValue(typeScreen);
    }
}


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