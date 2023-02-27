using SaveData;

public class ScreenData : SavingData<ScreenSetups>
{
    public ScreenData( string key )
    {
        base.Key = key;
    }
    
    public void SetupValue( TypesScreen typeScreen, bool value )
    {
        DataSetups.SetupValue(typeScreen, value);
        Save();
    }

    public bool GetValue(TypesScreen typeScreen)
    {
        return DataSetups.GetValue(typeScreen);
    }
}

