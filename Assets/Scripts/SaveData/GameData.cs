
public class GameData : SavingData<GameSetups>
{
    public GameData( string key, GameField gameField )
    {
        base.Key = key;
        _dataSetups._scaleBricks = gameField.CalculateScale();
       
    }

    
    public void SetupOptionValue( TypesGame typeGame )
    {
        _dataSetups.SetupOptionValue(typeGame);
        Save();
    }

    public void SetupOptionValue(TypesOption typeOption, bool value)
    {
        _dataSetups.SetupOptionValue(typeOption, value);
        Save();
    }
    
    public void SetupOptionValue(TypesOption typeOption, float value)
    {
        _dataSetups.SetupOptionValue(typeOption, value);
        Save();
    }


    public float GetOptionValue(TypesOption typeOption)
    {
        return _dataSetups.GetOptionValue(typeOption);
    }

    public int GetDifficultValue()
    {
        return _dataSetups.GetDifficultGameValue();
    }

    public void InitScale(float scale) => _dataSetups._scaleBricks = scale;
    
}