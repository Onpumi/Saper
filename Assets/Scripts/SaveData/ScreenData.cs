public class ScreenData : SavingData<ScreenSetups>
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

